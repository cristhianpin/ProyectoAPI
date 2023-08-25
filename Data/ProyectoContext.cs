using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using proyectodawa.Models;

namespace proyectodawa.Data;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Corte> Cortes { get; set; }

    public virtual DbSet<CorteBarba> CorteBarbas { get; set; }

    public virtual DbSet<CorteCabello> CorteCabellos { get; set; }

    public virtual DbSet<Peluquero> Peluqueros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PRIMARY");

            entity.ToTable("admins");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdAdmin)
                .ValueGeneratedNever()
                .HasColumnName("id_admin");
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("admins_ibfk_1");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PRIMARY");

            entity.ToTable("cita");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.Property(e => e.IdCita)
                .ValueGeneratedNever()
                .HasColumnName("id_cita");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("cita_ibfk_1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("clientes_ibfk_1");
        });

        modelBuilder.Entity<Corte>(entity =>
        {
            entity.HasKey(e => e.IdCortes).HasName("PRIMARY");

            entity.ToTable("cortes");

            entity.Property(e => e.IdCortes)
                .ValueGeneratedNever()
                .HasColumnName("id_cortes");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<CorteBarba>(entity =>
        {
            entity.HasKey(e => e.IdCortebarba).HasName("PRIMARY");

            entity.ToTable("corte_barba");

            entity.HasIndex(e => e.IdCortes, "id_cortes");

            entity.Property(e => e.IdCortebarba)
                .ValueGeneratedNever()
                .HasColumnName("id_cortebarba");
            entity.Property(e => e.IdCortes).HasColumnName("id_cortes");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCortesNavigation).WithMany(p => p.CorteBarbas)
                .HasForeignKey(d => d.IdCortes)
                .HasConstraintName("corte_barba_ibfk_1");
        });

        modelBuilder.Entity<CorteCabello>(entity =>
        {
            entity.HasKey(e => e.IdCortecabello).HasName("PRIMARY");

            entity.ToTable("corte_cabello");

            entity.HasIndex(e => e.IdCortes, "id_cortes");

            entity.Property(e => e.IdCortecabello)
                .ValueGeneratedNever()
                .HasColumnName("id_cortecabello");
            entity.Property(e => e.IdCortes).HasColumnName("id_cortes");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCortesNavigation).WithMany(p => p.CorteCabellos)
                .HasForeignKey(d => d.IdCortes)
                .HasConstraintName("corte_cabello_ibfk_1");
        });

        modelBuilder.Entity<Peluquero>(entity =>
        {
            entity.HasKey(e => e.IdPeluquero).HasName("PRIMARY");

            entity.ToTable("peluqueros");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdPeluquero)
                .ValueGeneratedNever()
                .HasColumnName("id_peluquero");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Peluqueros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("peluqueros_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
