using GameStoreApi.Data;
using GameStoreApi.Dtos;
using GameStoreApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Endpoints;

public static class GameEndpoints
{
    const string GetGameByIdEndpointName = "getGameById";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        
        //GET /games
        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToSummaryDto())
                .AsNoTracking()
                .ToListAsync();
        });

        //GET /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            
            var game = await dbContext.Games.FindAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToDetailsDto());
        }).WithName("getGameByIdEndpointName");

        //POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext ) =>
        {
            var game = newGame.ToEntity();

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("getGameByIdEndpointName", new { id = game.Id }, game.ToDetailsDto());
        });

        //PUT /games/1
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame == null)
            {
                return Results.NotFound();
            }
            
            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //Delete /games/1
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games
                .Where(game => game.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
    
}