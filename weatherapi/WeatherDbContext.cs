using Microsoft.EntityFrameworkCore;

public class WeatherDbContext : DbContext
{
    public DbSet<WeatherInfo> WeatherInfos => Set<WeatherInfo>();
}
public class WeatherInfo
{
    public required DateOnly date { get; set; }
    public required int Temperature { get; set; }
    public required string Description { get; set; }
    public required int WindSpeed { get; set; }
    public required string City { get; set; }
}