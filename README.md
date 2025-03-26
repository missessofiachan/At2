# Applicant Management

A web-based application built with ASP\.NET MVC for managing applicants. The application uses Bootstrap for styling and incorporates a simple dark mode switch in its layout. It is developed using C\# and JavaScript.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [JetBrains Rider 2024\.3\.6](https://www.jetbrains.com/rider/)
- An Internet connection for loading external Bootstrap and Google Fonts assets

## Project Structure

- `At2`  
  Contains the ASP\.NET MVC application including controllers, models, views, and other assets.

- `TestProject1`  
  Contains unit tests built using MSTest and Entity Framework Core.

## Running the Application

1\. Open the solution in JetBrains Rider\.  
2\. Restore the NuGet packages.  
3\. Build the solution to ensure that all dependencies are resolved.  
4\. Run the ASP\.NET project (`At2`)\.  
5\. The application will start and can be accessed via a web browser at the configured URL\(typically [https://localhost:5001](https://localhost:5001)\).

## Running Tests

1\. Open the solution in JetBrains Rider\.  
2\. Build the solution\.  
3\. Run tests from the Test Explorer in Rider or via the command line using:

```bash
dotnet test
