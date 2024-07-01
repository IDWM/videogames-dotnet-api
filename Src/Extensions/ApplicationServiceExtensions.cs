using Microsoft.EntityFrameworkCore;
using videogames_dotnet_api.Src.Data;
using videogames_dotnet_api.Src.Interfaces;
using videogames_dotnet_api.Src.Services;

namespace videogames_dotnet_api.Src.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IPhotoService, PhotoService>();

        return services;
    }
}
