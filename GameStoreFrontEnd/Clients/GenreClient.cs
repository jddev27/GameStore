using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients;

public class GenreClient(HttpClient httpClient)
{
    private readonly Genre[] genres = 
    [
        new() { Id = 1, Name = "Fighting" },
        new() { Id = 2, Name = "Roleplaying" },
        new (){ Id = 3, Name = "Sports" },
        new() { Id = 4, Name = "Racing" },
        new() { Id = 5, Name = "Kids and Family" }
    ];

    public Genre[] GetGenres() => [..genres];
}