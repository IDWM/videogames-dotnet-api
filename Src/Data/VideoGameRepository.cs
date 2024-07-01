using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using videogames_dotnet_api.Src.DTOs;
using videogames_dotnet_api.Src.Interfaces;
using videogames_dotnet_api.Src.Models;

namespace videogames_dotnet_api.Src.Data;

public class VideoGameRepository(
    DataContext dataContext,
    IMapper mapper,
    IPhotoService photoService
) : IVideoGameRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    private readonly IPhotoService _photoService = photoService;

    public async Task<object> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto)
    {
        var result = await _photoService.AddPhotoAsync(createVideoGameDto.Image);

        if (result.Error != null)
        {
            throw new Exception("Error al subir la imagen");
        }

        VideoGame videoGame = _mapper.Map<VideoGame>(
            createVideoGameDto,
            opts =>
            {
                opts.Items["Image"] = result.SecureUrl.AbsoluteUri;
                opts.Items["PublicId"] = result.PublicId;
            }
        );

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

    public Task<bool> ExistsVideoGameByNameAsync(string name)
    {
        return _dataContext.VideoGames.AnyAsync(x => x.Name == name);
    }

    public async Task<object?> GetVideoGameByIdAsync(int id)
    {
        return await _dataContext
            .VideoGames.ProjectTo<VideoGameDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<object>> GetVideoGamesAsync()
    {
        return await _dataContext
            .VideoGames.ProjectTo<VideoGameDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public Task<object> UpdateVideoGameAsync(int id, UpdateVideoGameDto updateVideoGameDto)
    {
        throw new NotImplementedException();
    }
}
