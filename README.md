# HealthClaimPro 🏥

A production-ready **Healthcare Claims Management REST API** built with ASP.NET Core 8, demonstrating clean architecture, containerization, and CI/CD best practices.

---

## 📌 Overview

HealthClaimPro is a backend API system designed to manage healthcare insurance claims end-to-end — from claim submission to approval tracking. Built to simulate real-world healthcare domain workflows with enterprise-grade tooling.

---

## 🚀 Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 8 Web API |
| ORM | Entity Framework Core 8 |
| Database | SQL Server 2022 |
| Containerization | Docker + Docker Compose |
| CI/CD | Azure DevOps YAML Pipeline |
| Testing | xUnit |
| API Docs | Swagger / OpenAPI |
| Auth | JWT Bearer Tokens |

---

## 🏗️ Architecture

```
HealthClaimPro/
├── Models/
│   ├── Claim.cs               # Core claim entity with row versioning
│   ├── User.cs                # User entity with role support
│   └── ApprovalHistory.cs     # Audit trail for claim approvals
├── Data/
│   └── AppDbContext.cs        # EF Core DbContext with row versioning
├── Migrations/                # EF Core database migrations
├── Properties/
│   └── launchSettings.json
├── Program.cs                 # App entry point, DI, middleware pipeline
├── appsettings.json           # Configuration
├── Dockerfile                 # Multi-stage production Dockerfile
└── docker-compose.yml         # App + SQL Server 2022 orchestration
```

---

## 📦 Domain Models

### Claim
Represents a healthcare insurance claim with status tracking and optimistic concurrency via SQL Server row versioning.

### User
Supports role-based access control (RBAC) for Patients, Providers, and Admins.

### ApprovalHistory
Full audit trail — every status change on a claim is recorded with timestamps and actor information.

---

## 🐳 Running with Docker

### Prerequisites
- Docker Desktop installed
- No local SQL Server required — included in compose

### Steps

```bash
# Clone the repository
git clone https://github.com/shivanik6666/HealthClaimPro.git
cd HealthClaimPro

# Start the application
docker compose up --build
```

API will be available at: `http://localhost:5000`
Swagger UI: `http://localhost:5000/swagger`

---

## 🖥️ Running Locally

### Prerequisites
- .NET 8 SDK
- SQL Server (local or Azure)

### Steps

```bash
# Restore dependencies
dotnet restore

# Update connection string in appsettings.json

# Apply migrations
dotnet ef database update

# Run the application
dotnet run
```

---

## ⚙️ Configuration

In `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HealthClaimProDb;..."
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key",
    "Issuer": "HealthClaimPro",
    "Audience": "HealthClaimProUsers"
  }
}
```

For Docker, environment variables use the `__` convention:
```
ConnectionStrings__DefaultConnection=Server=sqlserver;...
```

---

## 🧪 Running Tests

```bash
dotnet test
```

Tests are written using **xUnit** covering core business logic and API behavior.

---

## 🔄 CI/CD Pipeline

Azure DevOps YAML pipeline automates:
- ✅ Build & Restore
- ✅ Run Tests
- ✅ Docker Image Build
- ✅ Push to Container Registry
- ✅ Deploy

---

## 🌟 Key Features

- **Clean REST API** — standard HTTP verbs, proper status codes
- **Row Versioning** — optimistic concurrency on Claim entity (SQL Server `rowversion`)
- **Audit Trail** — every claim action logged in ApprovalHistory
- **Multi-stage Dockerfile** — lean production image
- **Docker Compose** — one-command full stack setup including SQL Server
- **JWT Auth** — role-based access control
- **Swagger** — auto-generated API documentation
- **xUnit Tests** — unit tested business logic

---

## 👩‍💻 Author

**Shivani** — .NET Backend Developer  
4+ years of experience building production systems in healthcare and government domains.

[![GitHub](https://img.shields.io/badge/GitHub-shivanik6666-black?logo=github)](https://github.com/shivanik6666)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).