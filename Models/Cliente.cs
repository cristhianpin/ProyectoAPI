using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public int? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
