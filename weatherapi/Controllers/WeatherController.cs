using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    List<string> WinterFantasyWeather = new List<string> { "Isdimma", "Frostnatt", "Snöstorm", "Glittrande snö", "Klar vinterdag" };
    List<string> WarmWeatherDescriptions = new List<string> { "Soligt", "Lätt molnighet", "Regnskur", "Halvklart", "Varm sommardag" };

    [HttpGet]
    public async Task<IActionResult> GetCityLongLat([FromQuery] string? city)
    {
        using var httpClient = new HttpClient();

        // Anropa en annan API
        CityInfo? response = await httpClient.GetFromJsonAsync<CityInfo>($"http://10.27.1.168:5171/api/v1/location?city={city.ToLower()}");

        var temp = Random.Shared.Next(-10, 30);
        var Desc = "";

        if (temp <= 0)
            Desc = WinterFantasyWeather[Random.Shared.Next(0, WinterFantasyWeather.Count)];
        else
            Desc = WarmWeatherDescriptions[Random.Shared.Next(0, WarmWeatherDescriptions.Count)];

        // if (!db.WeatherInfos.Any())
        // {

        // }
        WeatherInfo weatherInfo = new()
        {
            City = city,
            TempC = temp,
            WindSpeedMS = Random.Shared.Next(0, 20),
            Description = Desc,
            Longitude = response.Longitude,
            Latitude = response.Latitude,
            Date = DateOnly.FromDateTime(DateTime.Now)
        };
        // db.WeatherInfos.Add(weatherInfo);
        // await db.SaveChangesAsync();
        return Ok(weatherInfo);
    }
}
public record CityInfo(string Country, string Region, string City, string Latitude, string Longitude);

// Get from website/city
// Get till location/weather?city=Borås
// Vi får tillbaka longitud och latitud

// Vi kommer skapa data för cityn baserat på om vi får in /dagensdatum & citynamn
// ELLER: /historisk datum & city namn 
// ELLER: /framtids datum & citynamn

// Get from location/wlong,lat