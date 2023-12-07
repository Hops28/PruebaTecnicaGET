using PruebaTecnicaGET.Models;
using PruebaTecnicaGET.Repositories;

namespace PruebaTecnicaGET.Services
{
    public class Directorio
    {
        // FindPersonas()
        // FindPersonasByIdentification()
        // DeletePersonasByIdentification()
        // StorePersona()

        private PersonaRepositorio personaRepositorio;

        public Directorio(PersonaRepositorio personaRepositorio)
        {
            this.personaRepositorio = personaRepositorio;
        }

        public List<Persona> FindPersonas ()
        {
            var result = personaRepositorio.Select().ToList();

            return result;
        }

        public Persona? FindPersonas(int id)
        {
            var result = personaRepositorio.Find(id);

            return result;
        }

        /*************************/

        public Persona? FindPersonaByIdentificacion(string identificacion)
        {
            var result = personaRepositorio.Select().FirstOrDefault(x => x.Identificacion == identificacion);

            return result;
        }

        public void DeletePersonaByIdentificacion(string identificacion)
        {
            var persona = FindPersonaByIdentificacion(identificacion);
            personaRepositorio.Delete(persona!.Id);
        }

        public void StorePersona (Persona persona)
        {
            personaRepositorio.Insert(persona);
        }
    }
}
