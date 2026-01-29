using Microsoft.EntityFrameworkCore;

public class WeatherDbContext : DbContext
{
    public DbSet<WeatherInfo> WeatherInfos => Set<WeatherInfo>();
}