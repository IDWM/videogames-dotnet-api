using Microsoft.EntityFrameworkCore;
using videogames_dotnet_api.Src.Data;

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

        return services;
    }
}
