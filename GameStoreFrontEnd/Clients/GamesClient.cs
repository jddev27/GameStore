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
            Id = 1,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(1995, 7, 15)

        },
        new()
        {
            Id = 1,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 19.99M,
            ReleaseDate = new DateOnly(2023, 7, 15)

        }
    ];

    public GameSummary[] GetGames() => [.. games];

}