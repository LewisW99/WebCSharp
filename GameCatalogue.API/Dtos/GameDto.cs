namespace GameCatalogue.API.Dtos;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Data transfer object for exposing games to clients.
/// </summary>
public sealed class GameDto
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Range(0, 100)]
    public double Rating { get; set; }

    [Required, MaxLength(100)]
    public string Genre { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Platform { get; set; } = string.Empty;
}
