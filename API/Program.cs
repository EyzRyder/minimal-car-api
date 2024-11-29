using MinimalCarApi.Infraestrutura.Db;
using MinimalCarApi.Dominio.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))
        );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@test.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login com Sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
