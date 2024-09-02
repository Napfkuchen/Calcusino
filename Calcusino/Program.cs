using Microsoft.EntityFrameworkCore;
using Calcusino.Data;

var builder = WebApplication.CreateBuilder(args);

// Passwort aus der Umgebungsvariablen holen
var password = Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD");
var connectionString = $"Server=localhost;Database=calcusino;User=root;Password={password};";

// Add services to the container.
// Füge den DbContext hinzu
builder.Services.AddDbContext<CalcusinoDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("CalcusinoDatabase")
    ?? throw new InvalidOperationException("Connection string 'CalcusinoDatabase' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
