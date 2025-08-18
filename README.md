# Backend - .NET Core 9 Clean Architecture


A .NET Core 9 Web API project built with Clean Architecture principles, featuring PostgreSQL integration, Swagger documentation, and Docker support.

## Architecture

This project follows Clean Architecture principles with the following layers:

- **Core**: Domain entities and interfaces
- **Application**: Application logic, DTOs, and MediatR handlers
- **Infrastructure**: Data access and external service implementations
- **API**: Web API controllers and configuration

## Features

- .NET Core 9
- Clean Architecture
- Entity Framework Core with PostgreSQL
- MediatR for CQRS pattern
- Swagger/OpenAPI documentation
- Docker support
- User management API (Create and Get operations)

## Prerequisites

- .NET 9 SDK
- Docker and Docker Compose
- PostgreSQL (if running locally without Docker)

## Getting Started

### Option 1: Run with Docker Compose (Recommended)

1. **Start the database only:**
   ```bash
   docker-compose up -d postgres
   ```

2. **Run the application:**
   ```bash
   dotnet run --project backend.API
   ```

### Option 2: Run everything with Docker Compose

1. **Start all services:**
   ```bash
   docker-compose -f docker-compose.full.yml up -d
   ```

   This will start both PostgreSQL and the .NET application.

### Option 3: Run locally

1. **Start PostgreSQL:**
   ```bash
   docker-compose up -d postgres
   ```

2. **Update connection string** in `backend.API/appsettings.json` if needed.

3. **Run the application:**
   ```bash
   dotnet run --project backend.API
   ```

## API Endpoints

Once the application is running, you can access:

- **Swagger UI**: http://localhost:5246/swagger
- **API Base URL**: http://localhost:5246/api

### Available Endpoints

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create a new user

### Example API Usage

#### Create a User
```bash
curl -X POST "http://localhost:5246/api/users" \
     -H "Content-Type: application/json" \
     -d '{
       "firstName": "John",
       "lastName": "Doe",
       "email": "john.doe@example.com",
       "phoneNumber": "+1234567890"
     }'
```

#### Get All Users
```bash
curl -X GET "http://localhost:5246/api/users"
```

#### Get User by ID
```bash
curl -X GET "http://localhost:5246/api/users/1"
```

## Database

The application uses PostgreSQL with the following default configuration:
- **Host**: localhost (or postgres when using Docker)
- **Port**: 5432
- **Database**: backend_db
- **Username**: postgres
- **Password**: postgres

## Project Structure

```
backend/
├── backend.API/           # Web API layer
│   ├── Controllers/       # API controllers
│   ├── Program.cs         # Application configuration
│   └── appsettings.json  # Configuration
├── backend.Application/   # Application layer
│   ├── Commands/         # MediatR commands
│   ├── Queries/          # MediatR queries
│   ├── Handlers/         # Command/Query handlers
│   └── DTOs/            # Data Transfer Objects
├── backend.Core/         # Domain layer
│   ├── Entities/         # Domain entities
│   └── Interfaces/       # Repository interfaces
├── backend.Infrastructure/ # Infrastructure layer
│   ├── Data/             # DbContext and configurations
│   └── Repositories/     # Repository implementations
├── docker-compose.yml    # Database only
├── docker-compose.full.yml # Full application
├── Dockerfile            # .NET application container
└── README.md            # This file
```

## Development

### Building the Solution
```bash
dotnet build
```

### Running Tests
```bash
dotnet test
```

### Adding New Features

1. **Domain Layer**: Add entities and interfaces in `backend.Core`
2. **Application Layer**: Add DTOs, commands, queries, and handlers in `backend.Application`
3. **Infrastructure Layer**: Implement repositories in `backend.Infrastructure`
4. **API Layer**: Add controllers in `backend.API`

## Docker Commands

### Database Only
```bash
# Start database
docker-compose up -d postgres

# Stop database
docker-compose down

# View logs
docker-compose logs postgres
```

### Full Application
```bash
# Start all services
docker-compose -f docker-compose.full.yml up -d

# Stop all services
docker-compose -f docker-compose.full.yml down

# View logs
docker-compose -f docker-compose.full.yml logs
```

## Troubleshooting

### Common Issues

1. **Port conflicts**: Ensure ports 5000, 5001, and 5432 are available
2. **Database connection**: Verify PostgreSQL is running and accessible
3. **SSL certificate**: The application uses HTTPS by default in development

### Reset Database
```bash
docker-compose down -v
docker-compose up -d postgres
```

## Contributing

1. Follow Clean Architecture principles
2. Use MediatR for CQRS pattern
3. Implement proper error handling
4. Add appropriate validation
5. Write unit tests for business logic

## License

This project is open source and available under the [MIT License](LICENSE).
