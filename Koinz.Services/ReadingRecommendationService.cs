using Koinz.Common;
using Koinz.DataProvider.EFCore.Context;
using Koinz.DataProvider.EFCore.Models;
using Koinz.Interfaces;
using Koinz.Model.DTOs;
using Koinz.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.Services
{
    public class ReadingRecommendationService : IReadingRecomendation
    {
        public async Task SubmitReadingInteraval(ReadingIntervalDTO readingIntervalDTO)
        {
            using (var readingIntervalContext = new ReadingRecommendationDBContext<ReadingInterval>())
            {
                var readingInterval = new ReadingInterval
                {
                    UserId = readingIntervalDTO.UserId,
                    BookId = readingIntervalDTO.BookId,
                    StartPage = readingIntervalDTO.StartPage,
                    EndPage = readingIntervalDTO.EndPage
                };
                await readingIntervalContext.SaveAsync(readingInterval);
                // Send SMS using chosen provider based on environment variable

                var smsProviderUrl = AppConfigrationManager.AppSettings["SMS_PROVIDER_URL"];
                if (smsProviderUrl != null)
                {
                    await SendSMSAsync((int)readingInterval.UserId, smsProviderUrl);
                }
            }

        }

        public async Task<List<RecommendedBookVM>> GetRecommendedBooks()
        {
            try
            {
                var totalPagesReadPerBook = CalculateTotalPagesReadPerBook();

                var mostReadBooks = await GetTopRecommendedBooks(totalPagesReadPerBook);

                return mostReadBooks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting recommended books", ex);
            }
        }

        private Dictionary<int, HashSet<int>> CalculateTotalPagesReadPerBook()
        {
            using (var readingIntervalContext = new ReadingRecommendationDBContext<ReadingInterval>())
            {
                var bookPages = new Dictionary<int, HashSet<int>>();
                foreach (var interval in readingIntervalContext.ReadingIntervals.ToList())
                {
                    if (!bookPages.ContainsKey((int)interval.BookId))
                    {
                        bookPages.Add((int)interval.BookId, new HashSet<int>());
                    }

                    foreach (int page in Enumerable.Range((int)interval.StartPage, (int)interval.EndPage - (int)interval.StartPage + 1))
                    {
                        bookPages[(int)interval.BookId].Add(page); // Add only unique pages
                    }
                }
                return bookPages;
            }
        }

        private async Task<List<RecommendedBookVM>> GetTopRecommendedBooks(Dictionary<int, HashSet<int>> totalPagesReadPerBook)
        {
            using (var bookContext = new ReadingRecommendationDBContext<Book>())
            {
                var mostReadBooks =  totalPagesReadPerBook
                    .Select(bp => new RecommendedBookVM
                    {
                        BookId = bp.Key,
                        BookName = bookContext.Books.Find(bp.Key)?.BookName, // Retrieve book name
                        NumOfReadPages = bp.Value.Count - 1// Number of unique pages
                    })
                    .OrderByDescending(br => br.NumOfReadPages)
                    .Take(5)
                    .ToList();

                return mostReadBooks;
            }
        }

        private async Task SendSMSAsync(int userId, string smsProviderUrl)
        {

            using (var client = new HttpClient())
            {
                var content = new StringContent($"Thank you for submitting your reading interval! - UserId: {userId}", Encoding.UTF8, "application/json");
                await client.PostAsync(smsProviderUrl, content);
            }
        }



    }
}
