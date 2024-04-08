using Koinz.Model.DTOs;
using Koinz.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.Interfaces
{
    public interface IReadingRecomendation
    {
        Task SubmitReadingInteraval(ReadingIntervalDTO readingIntervalDTO);
        Task<List<RecommendedBookVM>> GetRecommendedBooks();
    }
}
