using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client;
using PruebaTecnicaGET.Models;

namespace PruebaTecnicaGET.Repositories
{
    public class FacturaRepositorio
    {
        private PruebaGettechContext _context;

        public FacturaRepositorio(PruebaGettechContext context)
        {
            this._context = context;
        }

        public IQueryable<Factura> Select ()
        {
            // Control del motor de la bases de datos de forma optimizada con Queryable
            var resultado = _context.Facturas.AsQueryable();

            return resultado;
        }

        public Factura? Find (int id)
        {
            var resultado = this.Select().FirstOrDefault(x => x.Id == id);

            return resultado;
        }

        /**********************************/

        // Por si es una
        public void Insert (Factura factura)
        {
            _context.Add(factura);
            _context.SaveChanges();
        }

        // Por si son varias
        public void Insert(List<Factura> facturas)
        {
            foreach (Factura factura in facturas) {
                _context.Add(factura);
            }

            _context.SaveChanges();
        }

        /**********************************/

        public void Update (int id, Factura facturaActualizada)
        {
            var factura = this.Find(id);

            factura!.Fecha = facturaActualizada.Fecha;

            _context.SaveChanges();
        }

        public void Delete (int id)
        {
            var factura = this.Find(id);

            _context.Remove(factura!);
            _context.SaveChanges();
        }
    }
}
