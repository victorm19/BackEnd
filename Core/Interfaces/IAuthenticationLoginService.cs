using Prueba.Net.Entities;

namespace Prueba.Net.Core.Interfaces
{
    public interface IAuthenticationLoginService
    {
        Respuesta<string> Login(Login login);
    }
}
