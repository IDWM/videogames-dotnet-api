using videogames_dotnet_api.Src.DTOs;
using videogames_dotnet_api.Src.Interfaces;
using videogames_dotnet_api.Src.Models;

namespace videogames_dotnet_api.Src.Data;

public class VideoGameRepository(DataContext dataContext, IPhotoService photoService)
    : IVideoGameRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IPhotoService _photoService = photoService;

    public async Task<object> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto)
    {
        var result = await _photoService.AddPhotoAsync(createVideoGameDto.Image);

        if (result.Error != null)
        {
            throw new Exception("Error al subir la imagen");
        }

        VideoGame videoGame =
            new()
            {
                Name = createVideoGameDto.Name,
                Description = createVideoGameDto.Description,
                Platform = createVideoGameDto.Platform,
                Price = createVideoGameDto.Price,
                ReleaseDate = createVideoGameDto.ReleaseDate,
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

        await _dataContext.VideoGames.AddAsync(videoGame);

        if (0 < await _dataContext.SaveChangesAsync())
        {
            return videoGame;
        }

        throw new Exception("Error al crear el videojuego");
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
