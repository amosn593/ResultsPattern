using Microsoft.EntityFrameworkCore;
using ResultPattern.Domain.Interfaces;
using ResultPattern.EndPoints;
using ResultPattern.Infrastructure.Data;
using ResultPattern.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("ResultPatternDb");
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapUserEndPoints();

app.Run();

