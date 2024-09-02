using Microsoft.EntityFrameworkCore;
using ApiWithRole2.Data;
using ApiWithRole2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DESKTOP-U7KSJ1K\\SQLEXPRESS")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the TokenService with the path to the Tokens folder
var tokenFolderPath = Path.Combine(builder.Environment.ContentRootPath, "Tokens");
builder.Services.AddSingleton(new TokenService(tokenFolderPath));

builder.Services.AddTransient<AuthService>();

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
