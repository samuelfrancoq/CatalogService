# Catalog Service – RESTful Web API

This project is an advanced implementation of the **Catalog Service**, following a **Clean Architecture** approach and strictly adhering to **RESTful architectural principles**.

---

## Architecture & Design

The solution is divided into four main layers:

- **Domain**
- **Application**
- **Infrastructure**
- **API**

This ensures complete separation of concerns. In this version, the service has been evolved to meet **high-level maturity standards**.

---

## REST Implementation & Maturity

### Richardson Maturity Model

- **Level 2**
  - Implements proper HTTP verbs: `GET`, `POST`, `PUT`, `DELETE`
  - Uses meaningful HTTP status codes

- **Level 3 (HATEOAS)**
  - Resources include hypermedia links (`_links`)
  - Enables client navigation through API state transitions  
    _Example: a Category resource provides links to its related Products_

### Versioning

- Supports API versioning via URL segments  
  _Example:_ `/api/v1/`

### OpenAPI (Swagger)

- Fully documented API
- Separate documentation sets for each API version

---

## Key Features

### Advanced Product Catalog

- Support for **categories** and **products**
- Full **CRUD operations**

### Pagination & Filtering

- Server-side pagination
- Category-based filtering

### Data Integrity

- Implements **Cascade Delete**
- Deleting a category automatically removes all associated products
- Managed via **EF Core Fluent API**

### DTO Mapping

- Decouples internal entities from public-facing contracts
- Enhanced with **HATEOAS support**

---

## Non-Functional Requirements (NFR)

### Testability

#### Unit Testing

- Comprehensive tests for the **Application layer**
- Uses **Moq** to validate:
  - Business logic
  - Mapping

#### Integration Testing

- High-level tests using **WebApplicationFactory**
- Verifies:
  - Full API pipeline
  - Correct HTTP responses
  - HATEOAS link generation

---

## Documentation & Standards

### OpenAPI Specification

- Automatic documentation generation using **Swagger**
- Tailored to reflect:
  - API versioning
  - Resource constraints

### Analyzers

- Uses **Web API analyzers**
- Enforces REST best practices during development

---

## Getting Started

### Database Setup

1. Verify the connection string in `appsettings.json`
2. Set **Infrastructure** as the default project in Package Manager Console
3. Run:

```powershell
Update-Database
```

4. Execution: - Run the project (F5).
Access the Swagger UI at /swagger to explore the different API versions.
5. Running Tests:
Use the Test Explorer in Visual Studio to run both Unit and Integration tests to ensure system stability.
