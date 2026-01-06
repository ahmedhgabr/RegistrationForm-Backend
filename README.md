# Registration Form Backend API

A RESTful API for user registration and management built with ASP.NET Core Web API, Entity Framework Core, and SQL Server.

## Features

- **User Registration** - Create new user accounts with validation
- **User Management** - Read, update, and delete user records
- **Email Search** - Find users by email query
- **Data Validation** - input validation with custom rules
- **API Documentation** - Interactive API docs with Scalar

## Requirements

### Software Requirements
- **.NET 10 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/10.0)
- **SQL Server** (Express or higher) - [Download SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Visual Studio 2026** (recommended) or **VS Code** with C# extension

### NuGet Packages
- `Microsoft.EntityFrameworkCore` (10.0.1)
- `Microsoft.EntityFrameworkCore.SqlServer` (10.0.1)
- `Microsoft.EntityFrameworkCore.Tools` (10.0.1)
- `Microsoft.AspNetCore.OpenApi` (10.0.0)
- `Scalar.AspNetCore` (latest)

## Setup Instructions

### 1. Clone the Repository
`git clone https://github.com/ahmedhgabr/RegistrationForm-Backend.git cd RegistrationForm-Backend`

### 2. Configure Database Connection

Update the connection string in `appsettings.json`:
`"ConnectionStrings":[Put your connection string here]`

### 3. Restore Dependencies
`dotnet restore`

### 4. Apply Database Migrations

This will create the `RegistrationFormDB` database and the `Users` table with a unique index on the `Email` column.

### 5. Run the Application
`dotnet run`
Or press **F5** in Visual Studio.

The API will start on:
- **HTTPS:** `https://localhost:7009/`

## API Documentation

Once the application is running, access the interactive API documentation:

**Scalar API Reference:** `https://localhost:7009/scalar/`

## CORS Configuration

The API is configured to accept requests from:
- `http://localhost:5173` (Development frontend)

To add more origins, modify `Program.cs`:


