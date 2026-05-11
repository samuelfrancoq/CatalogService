# Catalog Service – Clean Architecture

This project is an implementation of the Catalog Service following a Clean Architecture approach. The main goal is to ensure that business logic remains fully independent from external concerns such as the database and the API by organizing the solution into separate projects (DLLs).

## Architecture Overview

The solution is divided into four physical projects:

### Domain
- Represents the core of the application.
- Contains entities such as `Category` and `Product`.
- Defines repository interfaces.
- Has no external dependencies.

### Application
- Contains the business logic of the system.
- Includes services and Data Transfer Objects (DTOs).
- Interacts only with the Domain layer.

### Infrastructure
- Handles all technical and external concerns.
- Implements data access using Entity Framework Core and SQL Server.
- Uses Fluent API for configuring constraints (e.g., string length limits and data types such as money).

### API
- Provides the entry point to the system.
- Contains controllers and dependency injection configuration.

## Non-Functional Requirements

### Testability
- The Application layer is decoupled from the database.
- Allows unit testing without requiring a running database.
- Uses Moq to mock dependencies and verify behavior.
- Ensures correct mapping between entities and DTOs.

### Extensibility
- The architecture allows easy replacement of external components.
- Example: switching from SQL Server to another database (e.g., PostgreSQL or DynamoDB) requires changes only in the Infrastructure layer.
- The use of DTOs prevents breaking changes in the API when modifying the database schema.

## Getting Started

Follow these steps to run the project locally:

1. Verify the connection string in `appsettings.json`.
2. Open the Package Manager Console and set the default project to `Infrastructure`.
3. Run:
   ```powershell
   Update-Database
4. Hit F5 and check out the Swagger UI.