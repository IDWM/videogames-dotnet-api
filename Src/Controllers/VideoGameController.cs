using Microsoft.AspNetCore.Mvc;
using videogames_dotnet_api.Src.DTOs;
using videogames_dotnet_api.Src.Interfaces;

namespace videogames_dotnet_api.Src.Controllers;

public class VideoGameController(IVideoGameRepository videoGameRepository) : BaseApiController
{
    private readonly IVideoGameRepository _videoGameRepository = videoGameRepository;

    [HttpPost]
    public async Task<IResult> CreateVideoGameAsync(
        [FromForm] CreateVideoGameDto createVideoGameDto
    )
    {
        if (await _videoGameRepository.ExistsVideoGameByNameAsync(createVideoGameDto.Name))
        {
            ErrorDto errorDto = new() { Error = "El videojuego ya existe" };
            return TypedResults.BadRequest(errorDto);
        }

        try
        {
            var videoGame = await _videoGameRepository.CreateVideoGameAsync(createVideoGameDto);
            return TypedResults.Ok(videoGame);
        }
        catch (Exception e)
        {
            ErrorDto errorDto = new() { Error = e.Message };
            return TypedResults.BadRequest(errorDto);
        }
    }

    [HttpGet]
    public async Task<IResult> GetVideoGames()
    {
        var videoGames = await _videoGameRepository.GetVideoGamesAsync();
        return TypedResults.Ok(videoGames);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetVideoGameById([FromRoute] int id)
    {
        var videoGame = await _videoGameRepository.GetVideoGameByIdAsync(id);

        if (videoGame == null)
        {
            ErrorDto errorDto = new() { Error = "El videojuego no existe" };
            return TypedResults.NotFound(errorDto);
        }

        return TypedResults.Ok(videoGame);
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateVideoGameAsync(
        [FromRoute] int id,
        [FromForm] UpdateVideoGameDto updateVideoGameDto
    )
    {
        try
        {
            var videoGame = await _videoGameRepository.UpdateVideoGameAsync(id, updateVideoGameDto);
            return TypedResults.Ok(videoGame);
        }
        catch (Exception e)
        {
            ErrorDto errorDto = new() { Error = e.Message };
            return TypedResults.BadRequest(errorDto);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteVideoGameAsync([FromRoute] int id)
    {
        try
        {
            var videoGame = await _videoGameRepository.DeleteVideoGameAsync(id);
            return TypedResults.Ok(videoGame);
        }
        catch (Exception e)
        {
            ErrorDto errorDto = new() { Error = e.Message };
            return TypedResults.BadRequest(errorDto);
        }
    }
}
