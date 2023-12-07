using System;
using System.Collections.Generic;

namespace PruebaTecnicaGET.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string Identificacion { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
