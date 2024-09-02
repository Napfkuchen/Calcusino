using Microsoft.EntityFrameworkCore;
using Calcusino.Controllers;
using Calcusino.Data;
using Microsoft.OpenApi.Models;
using Calcusino.src.Backend.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddDbContext<CalcusinoDbContext>(options =>
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 26))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Calcusino API",
        Description = "API für die Calcusino-Anwendung",
        Contact = new OpenApiContact
        {
            Name = "Dein Name",
            Email = "deine.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        },
    });
});

// Nach der Service-Konfiguration wird die Anwendung gebaut
var app = builder.Build();

// Middleware-Konfiguration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcusino API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();