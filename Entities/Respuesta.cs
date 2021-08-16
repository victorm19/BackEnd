using System.Collections.Generic;

namespace Prueba.Net.Entities
{
    public class Respuesta<T>
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public List<T> Datos { get; set; }
    }
}
