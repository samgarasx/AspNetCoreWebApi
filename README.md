## Introduction

This project is a an example of [ASP.NET Core](https://www.asp.net/core/overview/aspnet-vnext/) web framework for a Web API.

The database engine used by the project is [SQLite](https://www.sqlite.org/).

### Getting Started

To create and migrate the database:

1. Initialize and migrate database with `dotnet ef database update `

To start the ASP.NET Core server:

1. Install dependencies with `dotnet restore`
2. Build executables with `dotnet build`
3. Start ASP.NET Core server with `dotnet run --environment=Development`

Now you can visit http://localhost:3000/api from your browser.
