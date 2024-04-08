using Koinz.Interfaces;
using Koinz.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Koinz_Assignment.Controllers
{
    [ApiController]
    [Route("api/reading-recommendation")]
    public class ReadingRecommendationController : ControllerBase
    { 
        private readonly IReadingRecomendation _readingRecomendation;

        public ReadingRecommendationController(IReadingRecomendation readingRecomendation)
        {
            _readingRecomendation = readingRecomendation;
        }

        /// <summary>
        /// Submits a user's reading interval for a book.
        /// </summary>
        /// <param name="readingInterval">The reading interval data.</param>
        /// <returns>Success message on successful submission.</returns>
        /// <response code="200">Reading interval submitted successfully.</response>
        /// <response code="400">One or more validation errors occurred.</response>

        [HttpPost("reading-interval")]
        public async Task<IActionResult> SubmitReadingInteraval([FromBody] ReadingIntervalDTO readingInterval)
        {
            // Validate reading-interval input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _readingRecomendation.SubmitReadingInteraval(readingInterval);
                return Ok(new { Message = "user reading interval has been successfully submit" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        /// <summary>
        /// Retrieves a list of recommended books based on user reading habits.
        /// </summary>
        /// <returns>A list of recommended books.</returns>
        /// <response code="200">Successfully retrieved recommended books.</response>
        /// <response code="500">An unexpected error occurred.</response>
        [HttpGet("recommended-books")]
        public async Task<IActionResult> GetRecommendedBooks()
        {
            try
            {
                var recommendedBooks = await _readingRecomendation.GetRecommendedBooks();
                return Ok(recommendedBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while getting recommended books: {ex.Message}");
            }
        }


    }
}