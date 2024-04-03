using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    
    public async Task AddGameAsync(GameDetails gameDetails) => await httpClient.PostAsJsonAsync("games", gameDetails);

    public async Task<GameDetails> GetGameByIdAsync(int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
           ?? throw new Exception("Could not find game!");

    public async Task UpdateGameAsync(GameDetails updateGame)
        => await httpClient.PutAsJsonAsync<GameDetails>($"games/{updateGame.Id}", updateGame);

    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");
}