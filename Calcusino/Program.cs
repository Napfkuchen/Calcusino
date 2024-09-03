using Microsoft.EntityFrameworkCore;
using Calcusino.Controllers;
using Calcusino.Data;
using Microsoft.OpenApi.Models;
using Calcusino.src.Backend.Services;

var builder = WebApplication.CreateBuilder(args);
// Configuration for accessing the app's settings
var configuration = builder.Configuration;

// Add and configure the DbContext for MySQL
builder.Services.AddDbContext<CalcusinoDbContext>(options =>
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 26))));

// Add services for controllers
builder.Services.AddControllers();

// Add support for API endpoint exploration in Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();

// Add Razor Pages support
builder.Services.AddRazorPages();

// Dependency Injection for custom services and repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

// Add Swagger/OpenAPI support for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Calcusino API",
        Description = "API for the Calcusino application",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        },
    });
});

// Build the app
var app = builder.Build();

// Middleware configuration
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development mode for API testing and documentation
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcusino API v1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI the root of the application
    });
}

// Redirect HTTP to HTTPS for better security
app.UseHttpsRedirection();

// Serve static files like CSS, JS, and images
app.UseStaticFiles();

// Enable routing to map requests to the correct endpoints
app.UseRouting();

// Enable authorization middleware (if there is any authorization logic)
app.UseAuthorization();

// Map controller routes (API endpoints)
app.MapControllers();

// Map Razor Pages routes (for page navigation in the frontend)
app.MapRazorPages();

// Optional: Redirecting to the login page at program start
app.MapGet("/", context =>
{
    context.Response.Redirect("/Login");
    return Task.CompletedTask;
});

// Run the application
app.Run();