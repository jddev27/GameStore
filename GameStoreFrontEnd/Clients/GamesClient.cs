using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients;

public class GamesClient(HttpClient httpClient)
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1992, 7, 15)
        },
        new()
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(1995, 7, 15)
        },
        new()
        {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 19.99M,
            ReleaseDate = new DateOnly(2023, 7, 15)
        }
    ];

    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
       


    private readonly Genre[] genres = new GenreClient(httpClient).GetGenres();

    public void AddGame(GameDetails gameDetails)
    {
        var genre = GetGenreById(gameDetails.GenreId);

        var gameSummary = new GameSummary()
        {
            Id = games.Count + 1,
            Name = gameDetails.Name,
            Genre = genre.Name,
            Price = gameDetails.Price,
            ReleaseDate = gameDetails.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGameById(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updateGame)
    {
        var genre = GetGenreById(updateGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updateGame.Id);

        existingGame.Name = updateGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updateGame.Price;
        existingGame.ReleaseDate = updateGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return  genres.Single(genre => genre.Id == int.Parse(id));
    }
}