using MinimalCarApi.Infraestrutura.Db;
using MinimalCarApi.Dominio.DTOs;
using MinimalCarApi.Dominio.Interfaces;
using MinimalCarApi.Dominio.Servicos;
using MinimalCarApi.Dominio.ModelViews;
using MinimalCarApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))
        );
});

var app = builder.Build();
#endregion

#region Home
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Administradoeres
app.MapPost("/administradoeres/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login com Sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});
#endregion


#region Veiculos
app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) =>
{


    var veiculo = new Veiculo
    {
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano
    };
    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
});
#endregion

#region
app.UseSwagger();
app.UseSwaggerUI();

app.Run();

#endregion
