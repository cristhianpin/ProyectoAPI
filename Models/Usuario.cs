using System;
using System.Collections.Generic;

namespace proyectodawa.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Peluquero> Peluqueros { get; set; } = new List<Peluquero>();
}
