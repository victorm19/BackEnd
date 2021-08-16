using Prueba.Net.Entities;

namespace Prueba.Net.Core.Interfaces
{
    public interface IPersonaService
    {
        Respuesta<Personas> ObtenerPersonas();
        Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario);
        Respuesta<bool> Insertar(Personas persona, Usuarios usuario);
    }
}
