using Microsoft.EntityFrameworkCore;
using WorldCitites.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WorldCitiesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'WebAppWithEFCore1Context' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options => {
    // Prevents the JSON serializer from accepting both int and string for int properties
    options.SerializerOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.Strict;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

}

// Enable Swagger UI
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Open API v1");
    options.RoutePrefix = string.Empty;

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
