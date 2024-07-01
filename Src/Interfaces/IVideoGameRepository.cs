using videogames_dotnet_api.Src.DTOs;

namespace videogames_dotnet_api.Src.Interfaces;

public interface IVideoGameRepository
{
    Task<IEnumerable<VideoGameDto>> GetVideoGamesAsync();
    Task<VideoGameDto?> GetVideoGameByIdAsync(int id);
    Task<VideoGameDto> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto);
    Task<VideoGameDto> UpdateVideoGameAsync(int id, UpdateVideoGameDto updateVideoGameDto);
    Task<VideoGameDto> DeleteVideoGameAsync(int id);
    Task<bool> ExistsVideoGameByNameAsync(string name);
}
