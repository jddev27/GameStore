using GameStoreApi.Dtos;
using GameStoreApi.Entities;

namespace GameStoreApi.Mappings;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}