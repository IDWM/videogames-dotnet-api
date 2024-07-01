namespace videogames_dotnet_api.Src.DTOs;

public class VideoGameDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Platform { get; set; }
    public required int Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required string ImageUrl { get; set; }
}
