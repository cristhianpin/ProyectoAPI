using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Citum
{
    public int IdCita { get; set; }

    public int? IdCliente { get; set; }

    public TimeOnly? Hora { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
