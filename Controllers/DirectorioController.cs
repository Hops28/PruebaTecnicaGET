using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGET.Models;
using PruebaTecnicaGET.Services;

namespace PruebaTecnicaGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private Directorio directorio;

        public DirectorioController(Directorio directorio)
        {
            this.directorio = directorio;
        }

        //public IEnumerable<Persona> Get()
        //{
        //    var resultado = directorio.FindPersonas();
        //    return resultado;
        //}

        // Se obtienen todas las personas
        [HttpGet("personas")]
        public ActionResult<IEnumerable<Persona>> GetPersonas()
        {
            var personas = directorio.FindPersonas();
            return Ok(personas);
        }

        // Se obtiene una persona según la identificación
        [HttpGet("personas/{identificacion}")]
        public ActionResult<Persona> GetPersonaByIdentificacion(string identificacion)
        {
            var persona = directorio.FindPersonaByIdentificacion(identificacion);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // Se registra una persona
        [HttpPost("personas")]
        public ActionResult<Persona> PostPersona([FromBody] Persona persona)
        {
            if (persona == null)
            {
                return BadRequest();
            }

            directorio.StorePersona(persona);

            // Se manda una respuesta HTTP exitosa, donde se muestra el enlace hacia la acción 'GetPersonaByIdentificacion'
            // además del objeto recién creado
            return CreatedAtAction(nameof(GetPersonaByIdentificacion), new { identificacion = persona.Identificacion }, persona);
        }

        // Se elimina una persona
        [HttpDelete("personas/{identificacion}")]
        public IActionResult DeletePersonaByIdentificacion(string identificacion)
        {
            directorio.DeletePersonaByIdentificacion(identificacion);
            return NoContent();
        }
    }
}
