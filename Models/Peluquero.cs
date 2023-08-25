using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Peluquero
{
    public int IdPeluquero { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
