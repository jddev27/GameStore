using GameStoreApi.Data;
using GameStoreApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.Genres
                .Select(genere => genere.ToDto())
                .AsNoTracking()
                .ToListAsync();
            
        });

        return group;
    }
}