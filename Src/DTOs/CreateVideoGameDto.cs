namespace videogames_dotnet_api.Src.DTOs;

public class CreateVideoGameDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Platform { get; set; }
    public required int Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required IFormFile Image { get; set; }
}
