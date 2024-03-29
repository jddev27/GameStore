# GameStore API

The GameStore API is a RESTful API built with ASP.NET Core minimal api that provides endpoints for managing video games in a game store. It allows you to create, read, update, and delete game entries in the database.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Lite 

## Prerequisites

- .NET Core SDK
- SQL Lite 

## Installation

1. Clone the repository:

    `git clone https://github.com/jddev27/GameStore.git`
2. Navigate to the `GameStoreApi` directory:
   
   `cd GameStore/GameStoreApi`

3. Update the connection string in the `appsettings.json` file to match your database configuration. Running sql lite by default. 

4. Run the following command to apply any pending migrations and create the database:

    `dotnet ef database update`
5. Build and run the application:

    `dotnet run`

The API will start running on `http://localhost:5000`.

## Endpoints

### Games

- `GET /games`: Retrieve a list of all games (summary view).
- `GET /games/{id}`: Retrieve details of a specific game by ID.
- `POST /games`: Create a new game.
- `PUT /games/{id}`: Update an existing game by ID.
- `DELETE /games/{id}`: Delete a game by ID.

## Dependencies

- `GameStoreApi.Data`: Contains the database context and entity models.
- `GameStoreApi.Dtos`: Contains data transfer objects (DTOs) for mapping between entities and API responses.
- `GameStoreApi.Mappings`: Contains extension methods for mapping between entities and DTOs.


## License

This project is licensed under the [MIT License](LICENSE).