using Microsoft.EntityFrameworkCore;
using videogames_dotnet_api.Src.Data;

namespace videogames_dotnet_api.Src.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.MapControllers();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<WebApplication>>();
            logger.LogError(ex, "Error en la migración de la base de datos");
        }
    }
}
