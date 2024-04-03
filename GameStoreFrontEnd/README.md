# Game Store Front-End

This is a Blazor WebAssembly application that serves as the front-end for a game store. It allows users to view, create, edit, and delete games in the catalog.

## Features

- **View Game Catalog**: The home page (`/`) displays a table with all the games in the catalog, showing their ID, name, genre, price, and release date.
- **Create New Game**: Users can navigate to the `/editgame` page to create a new game.
- **Edit Game**: Each game in the catalog has an "Edit" button that takes the user to the `/editgame/{id}` page, allowing them to edit the game's details.
- **Delete Game**: Each game in the catalog has a "Delete" button that opens a modal asking for confirmation before deleting the game.

## Components

### `Pages/Index.razor`

This component displays the game catalog table and handles the initial data fetching.

### `Pages/EditGame.razor`

This component is responsible for creating and editing game details. It fetches the game data based on the provided `id` parameter and renders a form for editing the game's name, genre, price, and release date.

### `Shared/DeleteGame.razor`

This component renders a modal dialog for confirming the deletion of a game. It takes a `GameSummary` parameter and displays the game name in the modal title.

### `Clients/GamesClient.cs`

This class is a client for interacting with the game-related API endpoints. It provides methods for fetching games, adding a new game, getting a game by ID, updating a game, and deleting a game.

### `Clients/GenreClient.cs`

This class is a client for fetching the list of available genres from the API.

### `Models/GameSummary.cs` and `Models/GameDetails.cs`

These classes represent the data models for game summaries and game details, respectively.

## Dependencies

This application relies on the following NuGet packages:

- `Microsoft.AspNetCore.Components.WebAssembly`
- `Microsoft.AspNetCore.WebUtilities`

## Getting Started

To run this application locally, you'll need to have the .NET Core SDK installed. Then, follow these steps:

1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet restore` to restore the dependencies.
4. Run `dotnet run` to start the application.

The application will be available at `http://localhost:5031`.

