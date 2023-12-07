using PruebaTecnicaGET.Models;
using PruebaTecnicaGET.Repositories;

namespace PruebaTecnicaGET.Services
{
    public class Ventas
    {
        // FindFacturasByPersona()
        // StoreFacturas()

        private FacturaRepositorio facturaRepositorio;

        public Ventas(FacturaRepositorio facturaRepositorio)
        {
            this.facturaRepositorio = facturaRepositorio;
        }

        /***************************************************/

        public List<Factura> FindFacturasByPersona (int idPersona)
        {
            // Se obtienen las facturas y se filtran por el Id de la persona
            var facturas = facturaRepositorio.Select().Where(x => x.IdPersona == idPersona);
            
            // Se retornan todas esas facturas filtradas
            return facturas.ToList();
        }

        // No sé si es individual o varias, así que hice ambas
        public void StoreFactura (Factura factura)
        {
            facturaRepositorio.Insert(factura);
        }

        public void StoreFacturas(List<Factura> facturas)
        {
            facturaRepositorio.Insert(facturas);
        }
    }
}
