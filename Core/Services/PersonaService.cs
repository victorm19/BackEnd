using Prueba.Net.Core.Interfaces;
using Prueba.Net.Entities;
using Prueba.Net.Infrastructure.Interfaces;
using Utils;

namespace Prueba.Net.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public Respuesta<bool> Insertar(Personas persona, Usuarios usuario)
        {
            usuario.Pass = Seguridad.Encriptar(usuario.Pass);
            var resultado = _personaRepository.Insertar(persona, usuario);
            return resultado;
        }

        public Respuesta<Personas> ObtenerPersonas()
        {
            var resultado = _personaRepository.ObtenerPersonas();

            return resultado;
        }

        public Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario)
        {
            var resultado = _personaRepository.ObtenerUsuarioPorNombreUsuario(usuario);
            return resultado;
        }
    }
}
