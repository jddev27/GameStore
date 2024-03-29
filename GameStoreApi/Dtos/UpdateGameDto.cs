using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Dtos;

public record UpdateGameDto(
    string Name, 
    [Required]
    int GenreId, 
    [Range(1,100)]
    decimal Price, 
    DateOnly ReleaseDate
    );