using Serilog;
using WebApp_Library.Contexts;
using Microsoft.EntityFrameworkCore;
using WebApp_Library.Services;
using WebApp_Library.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog(
    options =>
        options
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("log.txt"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddScoped<IRentService, RentServiceImpl>();
builder.Services.AddScoped<IBookService, BookServiceImpl>();
builder.Services.AddScoped<IReaderService, ReaderServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();