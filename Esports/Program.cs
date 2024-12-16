using Esports.Model; // For the `PlayerContext` and other models
using Esports.Services; // For the `PlayerService` and other services
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PlayerCS")));

builder.Services.AddScoped<PlayerService>();

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
