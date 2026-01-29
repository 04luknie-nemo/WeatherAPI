using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetCityLongLat([FromQuery] string? city)
    {
        using var httpClient = new HttpClient();

        // // Anropa en annan API
        // CityInfo? response = await httpClient.GetFromJsonAsync<CityInfo>($"http://10.27.3.115:5171/api/v1/location/{city}");

        if (city == "Stockholm")
        {
            WeatherInfo weatherInfo = new()
            {
                Id = 100,
                City = city,
                TempC = 10,
                WindSpeedMS = 20,
                Description = "Soligt",
                Longitud = "18.0649",
                Latitud = "59.3326",
                Date = DateOnly.FromDateTime(DateTime.Now)
            };
            return Ok(weatherInfo);
        }
        else
        {
            WeatherInfo weatherInfoGävle = new()
            {
                Id = 101,
                City = city,
                TempC = -20,
                WindSpeedMS = 2,
                Description = "Kallt",
                Longitud = "44.4321",
                Latitud = "54.1245",
                Date = DateOnly.FromDateTime(DateTime.Now)
            };
            return Ok(weatherInfoGävle);
        }
        // Console.WriteLine("Fått svar");
        // var latitud = ;
        // var longitud = ;

    }
    // [HttpGet]
    // public async Task<IActionResult> GetCityByName([FromQuery] string? city)
    // {
    //     var getCity = await _db.Locations.FirstOrDefaultAsync(c => c.City.ToLower() == city.ToLower());
    //     if (getCity == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(getCity);
    // }

}
public record CityInfo(string Country, string Region, string City, string Latitud, string Longitud);

// {
//     "id": 1,
//     "country": "Sweden",
//     "region": "Stockholm",
//     "city": "Stockholm",
//     "latitude": "59.3294",
//     "longitude": "18.0686"
//   },

// Get from website/city
// Get till location/weather?city=Borås
// Vi får tillbaka longitud och latitud

// Vi kommer skapa data för cityn baserat på om vi får in /dagensdatum & citynamn
// ELLER: /historisk datum & city namn 
// ELLER: /framtids datum & citynamn

// Get from location/wlong,lat