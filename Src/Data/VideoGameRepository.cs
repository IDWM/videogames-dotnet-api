using videogames_dotnet_api.Src.DTOs;
using videogames_dotnet_api.Src.Interfaces;

namespace videogames_dotnet_api.Src.Data;

public class VideoGameRepository(DataContext dataContext) : IVideoGameRepository
{
    private readonly DataContext _dataContext = dataContext;

    public Task<object> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto)
    {
        throw new NotImplementedException();
    }

    public Task<object> DeleteVideoGameAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetVideoGameByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<object>> GetVideoGamesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateVideoGameAsync(int id, UpdateVideoGameDto updateVideoGameDto)
    {
        throw new NotImplementedException();
    }
}
