using videogames_dotnet_api.Src.DTOs;

namespace videogames_dotnet_api.Src.Interfaces;

public interface IVideoGameRepository
{
    Task<IEnumerable<object>> GetVideoGamesAsync();
    Task<object> GetVideoGameByIdAsync(int id);
    Task<object> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto);
    Task<object> UpdateVideoGameAsync(int id, UpdateVideoGameDto updateVideoGameDto);
    Task<object> DeleteVideoGameAsync(int id);
}
