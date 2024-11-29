using MinimalCarApi.Dominio.Interfaces;
using MinimalCarApi.Dominio.DTOs;
using MinimalCarApi.Dominio.Entidades;
using MinimalCarApi.Infraestrutura.Db;

namespace MinimalCarApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{

    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }

}
