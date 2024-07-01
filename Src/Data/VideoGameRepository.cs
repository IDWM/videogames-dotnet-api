using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudinaryDotNet.Actions;
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

    public async Task<VideoGameDto> CreateVideoGameAsync(CreateVideoGameDto createVideoGameDto)
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
            VideoGameDto videoGameDto = _mapper.Map<VideoGameDto>(videoGame);
            return videoGameDto;
        }

        throw new Exception("Error al crear el videojuego");
    }

    public async Task<VideoGameDto> DeleteVideoGameAsync(int id)
    {
        VideoGame videoGame =
            await _dataContext.VideoGames.FindAsync(id)
            ?? throw new Exception("Videojuego no encontrado");

        _dataContext.VideoGames.Remove(videoGame);

        if (0 < await _dataContext.SaveChangesAsync())
        {
            VideoGameDto videoGameDto = _mapper.Map<VideoGameDto>(videoGame);
            return videoGameDto;
        }

        throw new Exception("Error al eliminar el videojuego");
    }

    public Task<bool> ExistsVideoGameByNameAsync(string name)
    {
        return _dataContext.VideoGames.AnyAsync(x => x.Name == name);
    }

    public async Task<VideoGameDto?> GetVideoGameByIdAsync(int id)
    {
        return await _dataContext
            .VideoGames.ProjectTo<VideoGameDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<VideoGameDto>> GetVideoGamesAsync()
    {
        return await _dataContext
            .VideoGames.ProjectTo<VideoGameDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<VideoGameDto> UpdateVideoGameAsync(
        int id,
        UpdateVideoGameDto updateVideoGameDto
    )
    {
        VideoGame videoGame =
            await _dataContext.VideoGames.FindAsync(id)
            ?? throw new Exception("Videojuego no encontrado");

        _mapper.Map(updateVideoGameDto, videoGame);

        if (0 < await _dataContext.SaveChangesAsync())
        {
            VideoGameDto videoGameDto = _mapper.Map<VideoGameDto>(videoGame);
            return videoGameDto;
        }

        throw new Exception("Error al actualizar el videojuego");
    }
}
