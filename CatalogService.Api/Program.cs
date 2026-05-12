using Asp.Versioning;
using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("CatalogService.Api.IntegrationTests")]

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CatalogServiceConnection");
builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseSqlServer(connectionString));

// Registering the Repository (Infrastructure)
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();

// Registering the Service (Application)
builder.Services.AddScoped<ICatalogService, CatalogService.Application.Services.CatalogService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catalog API v1",
        Version = "v1",
        Description = "REST - Task 1"
    });
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.ReportApiVersions = true; 
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; 
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { } // For integration testing purposes