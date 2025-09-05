# InfoTrackBookingService
This solution implements a booking API using C# and .NET Core, following clean architecture principles:
- MediatR is used to decouple request handling.
- Interfaces abstract service and repository layers for easy testing and future extensibility.
- In-memory storage is designed to be easily replaceable with SQL Server via Entity Framework.
- Exception handling middleware ensures consistent error responses for invalid input and booking conflicts.
- Security features such as authentication and authorization are intentionally omitted due to the test nature of this project.
  
To run the solution:
- Clone the repository and open in Visual Studio or VS Code.
- Run dotnet restore and dotnet run.
- Use Swagger UI or Postman to test the POST /api/booking endpoint.
