## Reading Recommendation API
This project implements a Reading Recommendation API that allows users to submit their reading intervals for books and retrieve recommendations based on their reading habits.

# Features
Users can submit reading intervals (start and end page numbers) for books they've read.
The API calculates the total number of unique pages read for each book.
The API recommends books based on the most read books (number of unique pages read).
# Technologies
 - ASP.NET Core Web API
 - Entity Framework Core 
 - Swagger (for API documentation)
 - MYSQL
# Installation
1. Clone this repository.
2. Restore NuGet packages (if using Visual Studio):
3. Open the solution file (.sln)
4. Right-click on the project and select "Manage NuGet Packages..."
5. Click "Restore"
6. Use Db scripts for DB setup locally and change db config aswell in Appsetting.json
Usage
# 1. Running the API:

Build the project (e.g., using Visual Studio).
Run the executable file (.dll) generated in the bin folder.
# 2. API Endpoints:

Submit Reading Interval (POST /api/reading-recommendation/reading-interval):
Submits a user's reading interval for a book in the request body.
Request Body:
JSON
{
  "UserId": 1,
  "BookId": 2,
  "StartPage": 10,
  "EndPage": 20
}
Use code with caution.
Response:
Success (200): JSON object with a message indicating successful submission.
Error (400): JSON object with details about validation errors.
Get Recommended Books (GET /api/reading-recommendation/recommended-books):
Retrieves a list of recommended books based on user reading habits.
Response:
Success (200): JSON array containing recommended books with details like book ID, book name, and number of unique pages read.
Error (500): JSON object with an error message.
# 3. Sending SMS on Reading Interval Submission: 

This project includes optional logic to send an SMS notification to the user upon submitting a reading interval. However, it requires configuration:

Set the SMS_PROVIDER_URL environment variable to the URL of your chosen SMS provider API.
Integrate the code with your specific SMS provider's library for sending SMS messages.

# Documentation
API documentation is generated using Swagger. Access the Swagger UI at http://localhost:<port>/swagger (replace <port> with the actual port number where your API is running).
