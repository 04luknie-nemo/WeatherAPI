# WeatherAPI
Weather API to show locations and their weather data

// Skicka till hemsidan

Get /api/weather/

wetherAPI 
json
{
    "date": "2024-06-01",
    "temperature": 22,
    "description": "Soligt",
    "windSpeed": 5,
    "longitude": 18.0649,
    "latitude": 59.3326
}

public class WeatherInfo
{
    public int Id { get; set; }
    public required DateOnly Date { get; set; }
    public required int Temperature { get; set; }
    public required string Description { get; set; }
    public required int WindSpeed { get; set; }
    public required string City { get; set; }
}