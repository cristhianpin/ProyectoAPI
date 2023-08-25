using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
