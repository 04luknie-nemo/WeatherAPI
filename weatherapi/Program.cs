using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5266");

// Lägg till den DbContext ni skapar för er databas här
builder.Services.AddDbContext<WeatherDbContext>(options =>
   options.UseSqlite("Data Source=weatherapi.db"));

builder.Services.AddControllers();

//Låt detta vara kvar! Utan denna inställning kommer inte websidan att få access till API:et.
// Läs mer här: https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
    db.Database.EnsureCreated();
}

// Denna hör ihop med CORS-inställningen ovan
app.UseCors();

//Ni ska inte skriva era endpoints här i Program.cs utan i separata controllers, så använd denna:
app.MapControllers();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.Run();