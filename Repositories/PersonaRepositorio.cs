using PruebaTecnicaGET.Models;

namespace PruebaTecnicaGET.Repositories
{
    public class PersonaRepositorio
    {
        private PruebaGettechContext _context;

        public PersonaRepositorio(PruebaGettechContext context)
        {
            this._context = context;
        }

        public IQueryable<Persona> Select()
        {
            // Control del motor de la bases de datos de forma optimizada con Queryable
            var resultado = _context.Personas.AsQueryable();

            // Retorna el resultado
            return resultado;
        }

        public void Delete(int id)
        {
            var persona = this.Find(id);

            _context.Remove(persona!);
            _context.SaveChanges();
        }

        public void Insert(Persona persona)
        {
            _context.Add(persona);
            _context.SaveChanges();
        }

        public void Update(int id, Persona personaActualizada)
        {
            var persona = this.Find(id);

            persona!.Nombre = personaActualizada.Nombre;
            persona.ApellidoPaterno = personaActualizada.ApellidoPaterno;
            persona.ApellidoMaterno = personaActualizada.ApellidoMaterno;
            persona.Identificacion = personaActualizada.Identificacion;

            _context.SaveChanges();
        }

        public Persona? Find(int id)
        {
            var resultado = this.Select().FirstOrDefault(x => x.Id == id);

            return resultado;
        }
    }
}
