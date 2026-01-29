public class WeatherInfo
{
    public int Id { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public required int TempC { get; set; }
    public required string Description { get; set; }
    public required int WindSpeedMS { get; set; }
    public required string City { get; set; }
    public required string Longitud { get; set; }
    public required string Latitud { get; set; }
}