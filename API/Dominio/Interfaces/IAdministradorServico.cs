using MinimalCarApi.Dominio.DTOs;
using MinimalCarApi.Dominio.Entidades;

namespace MinimalCarApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);

}
