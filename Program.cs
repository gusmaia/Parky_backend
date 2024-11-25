using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Parky_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Env.Load();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseFirebird(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_DEV"));
});
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseFirebird(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
