using Microsoft.AspNetCore.Mvc;
using Prueba.Net.Core.Interfaces;
using Prueba.Net.Entities;

namespace Prueba.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet("ObtenerPersonas")]
        public IActionResult ObtenerPersonas()
        {
            var resultado = _personaService.ObtenerPersonas();
            return StatusCode(resultado.Codigo, resultado);
        } 
        
        [HttpPost]
        public IActionResult Insertar([FromBody]InsertarPersona insertarPersona)
        {
            var resultado = _personaService.Insertar(insertarPersona.persona, insertarPersona.usuario);
            return StatusCode(resultado.Codigo, resultado);
        }
    }
}
