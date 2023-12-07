using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaGET.Models;

public partial class PruebaGettechContext : DbContext
{
    public PruebaGettechContext()
    {
    }

    public PruebaGettechContext(DbContextOptions<PruebaGettechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E6N6548\\SQLEXPRESS;Database=pruebaGETTECH;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83FFED5BE18");

            entity.ToTable("Factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Factura__idPerso__3C69FB99");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3213E83F5A3F5797");

            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(25)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
