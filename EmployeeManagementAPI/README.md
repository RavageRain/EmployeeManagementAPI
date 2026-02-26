# Employee Management API

A RESTful ASP.NET Core Web API that implements secure user authentication and role based authorization using JWT and BCrypt.
This project demonstrates backend fundamentals including secure password handling, statelesse authentication, and clean API design.

# Features

- CRUD Operations for Employees
- User Registration and login
- Secure password hashing with BCrypt
- JWT-based authentication
- Role-based authorization (User/Admin)
- Entity Framework Core with SQL Server
- Async/await database operations
- Token experation handling
	
# Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT
- BCrypt.Net-Next
- C#
- Swagger

# Authentication and Security

- Passwords are hashed using BCrypt before storing them
- JWT tokens are given after successfully logging in
- Token contains username, role, and expiration
- Protected endpoints requires valid token
- JWT secret Keys are not stored in source control

# Setup Instructions

1. Clone the repository
2. Navigate into the project folder
3. Add your own JWT secret in appsettings
4. Update-database
5. Run


