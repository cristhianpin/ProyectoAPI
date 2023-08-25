using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Corte
{
    public int IdCortes { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<CorteBarba> CorteBarbas { get; set; } = new List<CorteBarba>();

    public virtual ICollection<CorteCabello> CorteCabellos { get; set; } = new List<CorteCabello>();
}
