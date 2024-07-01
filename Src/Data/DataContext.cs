using Microsoft.EntityFrameworkCore;
using videogames_dotnet_api.Src.Models;

namespace videogames_dotnet_api.Src.Data;

public class DataContext : DbContext
{
    public DbSet<VideoGame> VideoGames { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
}
