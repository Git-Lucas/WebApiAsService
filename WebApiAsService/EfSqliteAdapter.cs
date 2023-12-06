using Microsoft.EntityFrameworkCore;

namespace WebApiAsService;

public class EfSqliteAdapter : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\ProgramData\For People Softwares\Teste\MyDatabase.db");
    }
}
