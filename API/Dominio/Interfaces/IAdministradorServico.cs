using MinimalCarApi.Dominio.DTOs;
using MinimalCarApi.Dominio.Entidades;

namespace MinimalCarApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    Administrador? BuscaPorId(int id);
    List<Administrador> Todos(int? pagina);

}
