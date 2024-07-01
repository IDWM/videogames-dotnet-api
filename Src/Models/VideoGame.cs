namespace videogames_dotnet_api.Src.Models;

public class VideoGame
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Platform { get; set; }
    public required int Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required string ImageUrl { get; set; }
    public required string PublicId { get; set; }
}
