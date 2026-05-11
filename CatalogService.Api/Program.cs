using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();