using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/weather")]
public class WeatherController(WeatherDbContext db) : ControllerBase
{

    [HttpGet("{city:string}/{date:DateOnly}")]
    public IActionResult GetCityLongLat(string city, DateOnly date)
    {
        var latitud = ;

        WeatherInfo weatherInfo = new()
        {
            DateOnly =
        };
    }
}

// Get from website/city
// Get till location/weather?city=Borås
// Vi får tillbaka longitud och latitud

// Vi kommer skapa data för cityn baserat på om vi får in /dagensdatum & citynamn
// ELLER: /historisk datum & city namn 
// ELLER: /framtids datum & citynamn

// Get from location/wlong,lat