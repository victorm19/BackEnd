using Prueba.Net.Entities;

namespace Prueba.Net.Infrastructure.Interfaces
{
    public interface IPersonaRepository
    {
        Respuesta<Personas> ObtenerPersonas();
        Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario);
        Respuesta<bool> Insertar(Personas persona, Usuarios usuario);
    }
}
