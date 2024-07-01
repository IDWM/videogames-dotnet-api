using CloudinaryDotNet.Actions;
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
}
