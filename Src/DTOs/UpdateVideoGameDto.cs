namespace videogames_dotnet_api.Src.DTOs;

public class UpdateVideoGameDto
{
    public required string Description { get; set; }
    public required string Platform { get; set; }
    public required int Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
}
