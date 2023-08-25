using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class CorteCabello
{
    public int IdCortecabello { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? IdCortes { get; set; }

    public virtual Corte? IdCortesNavigation { get; set; }
}
