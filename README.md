# WorldCities API

A RESTful API built with ASP.NET Core (.NET 10) for managing world cities data. This API provides CRUD operations for city information including name, country, and population.

This project is a Lexicon assignment.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete city records
- **Entity Framework Core**: Database management with SQL Server
- **Swagger/OpenAPI**: Interactive API documentation
- **Data Validation**: Built-in validation for population values
- **Seed Data**: Pre-populated with sample cities (New York, Tokyo, London)

## Technology Stack

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server (LocalDB)**
- **Swagger/OpenAPI**

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- SQL Server LocalDB (included with Visual Studio)
- Visual Studio or Visual Studio Code

## Getting Started

### 1. Clone the Repository

### 2. Update Database Connection String

The default connection string in `appsettings.json` uses LocalDB:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WorldCitiesDb;Trusted_Connection=True;"
}
```

Modify this if you're using a different SQL Server instance.

### 3. Apply Database Migrations

Run the following command in the Package Manager Console or terminal:

```
Update-Database
```

or using the .NET CLI:

```
dotnet ef database update
```

This will create the database and apply all necessary migrations.


### 4. Run the API

Start the API using Visual Studio or the .NET CLI:

```
dotnet run
```

The API will be available at `https://localhost:<port>` (port number will be displayed in the console).

## API Documentation

Once the application is running, navigate to the root URL (`https://localhost:<port>/`) to access the Swagger UI for interactive API documentation and testing.

## API Endpoints

### Get All Cities

GET /api/WorldCities

Returns all cities ordered by population (descending).

**Response:**

- `200 OK` with a list of city objects

### Get City by ID

GET /api/WorldCities/id

Returns the city with the specified ID.

**Parameters:**
- `id` (integer): City ID

**Response:**

- `200 OK` with the city object
- `404 Not Found` if the city does not exist

### Create City

POST /api/WorldCities

```json
{ 
	"city": "Paris", 
	"country": "France", 
	"population": 2161000 
}
```

**Response:**

- `201 Created` with the created city object
- `400 Bad Request` if the data is invalid

### Update City

POST /api/WorldCities/id/update

```json
{
  "name": "new name",
  "country": "new country",
  "population": 0
}
```

**Parameters:**
- `id` (integer): City ID

**Response:**

- `204 No Content` if the update was successful
- `400 Bad Request` if the data is invalid
- `404 Not Found` if the city does not exist

### Delete City

POST /api/WorldCities/id/delete

**Parameters:**
- `id` (integer): City ID

**Response:**

- `204 No Content` if successful
- `404 Not Found` if the city does not exist

### WorldCity

| Property   | Type   | Description                    |
|------------|--------|--------------------------------|
| CityId     | int    | Primary key (auto-generated)   |
| City       | string | City name                      |
| Country    | string | Country name                   |
| Population | int    | Population (non-negative)      |

## Development Notes

- The API uses POST methods for Update and Delete operations (instead of PUT/DELETE)
- Population values are validated to be non-negative integers
- JSON serialization uses strict number handling to prevent type coercion

## Error Handling

Errors are returned with appropriate HTTP status codes and a JSON body containing the error message.

## Author & Repository

- GitHub: [@arden-rh](https://github.com/arden-rh)
- Repository: [WorldCities WebAPI](https://github.com/arden-rh/lexicon-webapi-world-cities)

## License

© 2026 Arden Haldorson




