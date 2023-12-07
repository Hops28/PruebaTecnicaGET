using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGET.Models;
using PruebaTecnicaGET.Services;
using System.IO;

namespace PruebaTecnicaGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private Ventas ventas;

        public FacturaController(Ventas ventas)
        {
            this.ventas = ventas;
        }

        // Obtener facturas por ID de persona
        [HttpGet("facturas/{idPersona}")]
        public ActionResult<IEnumerable<Persona>> GetFacturasPorPersona(int idPersona)
        {
            var facturas = ventas.FindFacturasByPersona(idPersona);

            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        // Se registra una factura
        [HttpPost("facturas")]
        public ActionResult<Factura> PostFactura([FromBody] Factura factura)
        {
            if (factura == null)
            {
                return BadRequest();
            }

            ventas.StoreFactura(factura);

            // Se manda una respuesta HTTP exitosa, donde se muestra el enlace hacia la acción 'GetPersonaByIdentificacion'
            // además del objeto recién creado
            return CreatedAtAction(nameof(GetFacturasPorPersona), new { idPersona = factura.IdPersona }, factura);
        }
    }
}
