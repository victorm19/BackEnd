using Prueba.Net.Entities;

namespace Prueba.Net.Infrastructure.Interfaces
{
    public interface IAuthenticationRepository
    {
        Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario);
    }
}
