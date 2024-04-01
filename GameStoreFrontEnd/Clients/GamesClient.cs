using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients;

public class GamesClient
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

    public GameSummary[] GetGames() => [.. games];


    private readonly Genre[] genres = new GenreClient().GetGenres();

    public void AddGame(GameDetails gameDetails)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(gameDetails.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(gameDetails.GenreId));

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
}