using AutoMapper;
using videogames_dotnet_api.Src.DTOs;
using videogames_dotnet_api.Src.Models;

namespace videogames_dotnet_api.Src.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CreateVideoGameDto, VideoGame>()
            .ForMember(
                dest => dest.ImageUrl,
                opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Image"])
            )
            .ForMember(
                dest => dest.PublicId,
                opt => opt.MapFrom((src, dest, destMember, context) => context.Items["PublicId"])
            );

        CreateMap<VideoGame, VideoGameDto>();

        CreateMap<UpdateVideoGameDto, VideoGame>();
    }
}
