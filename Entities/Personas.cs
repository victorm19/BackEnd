using System;

namespace Prueba.Net.Entities
{
    public class Personas
    {
        public int Identificador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificación { get; set; }
        public string Email { get; set; }
        public string TipoIdentificación { get; set; }
        public DateTime FechaCreación { get; set; }
        public string IdentificacionCompleta { get; set; }
        public string NombresCompletos { get; set; }
    }
}
