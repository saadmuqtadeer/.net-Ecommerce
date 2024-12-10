using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseInMemoryDatabase("ProductDb");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
