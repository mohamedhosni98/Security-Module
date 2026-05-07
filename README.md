#  Security Module Demo

A robust, production-ready Authentication and Authorization module built with **.NET 8 Web API**. This project demonstrates a clean implementation of **ASP.NET Core Identity** and **JWT Bearer Authentication** with automated data seeding.

##  Features

- **Identity Management:** Full integration with ASP.NET Core Identity for user and role management.
- **JWT Authentication:** Secure token-based authentication with custom configurations (Issuer, Audience, Lifetime).
- **Automated Data Seeding:** A sophisticated "Orchestrator" pattern that automatically seeds:
  - **Application Roles** (e.g., Admin, User).
  - **Default Admin Account** (using settings from `appsettings.json`).
- **Clean Architecture Principles:** 
  - Interface-based seeding (`IDataSeeder`).
  - Use of `sealed` classes for performance and security.
  - Dependency Injection for all services.
- **AutoMapper:** Integrated for clean object mapping between entities and DTOs.

## Tech Stack

- **Framework:** .NET 8 Web API
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Security:** ASP.NET Core Identity, JWT Bearer
- **Mapping:** AutoMapper

##  Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 or VS Code

##  Setup & Installation

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/YourUsername/Security_Module_Demo.git](https://github.com/YourUsername/Security_Module_Demo.git)
   cd Security_Module_Demo
