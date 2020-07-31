using System;
using factura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace factura.Data
{
    public partial class facturaContext : DbContext
    {
        public facturaContext()
        {
        }

        public facturaContext(DbContextOptions<facturaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetalleProductosFactura> DetalleProductosFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_id");

                entity.Property(e => e.CategoriaNombre)
                    .HasColumnName("Categoria_nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetalleProductosFactura>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__DetalleP__CED7B6170E6E45D8");

                entity.Property(e => e.DetalleId).HasColumnName("Detalle_id");

                entity.Property(e => e.DetalleCantidad).HasColumnName("Detalle_cantidad");

                entity.Property(e => e.DetalleIva).HasColumnName("Detalle_iva");

                entity.Property(e => e.DetallePrecioTotal).HasColumnName("Detalle_precio_total");

                entity.Property(e => e.DetallePrecioUnitario).HasColumnName("Detalle_precio_unitario");

                entity.Property(e => e.DetalleSubTotal).HasColumnName("Detalle_sub_total");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_id");

                entity.Property(e => e.ProductosId).HasColumnName("Productos_id");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleProductosFactura)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK__DetallePr__Factu__2D27B809");

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.DetalleProductosFactura)
                    .HasForeignKey(d => d.ProductosId)
                    .HasConstraintName("FK__DetallePr__Produ__2E1BDC42");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId).HasColumnName("Factura_id");

                entity.Property(e => e.FacturaDescripcion)
                    .HasColumnName("Factura_descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.PersonaId).HasColumnName("Persona_Id");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK__Factura__Persona__2A4B4B5E");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.PersonaId)
                    .HasName("PK__Personas__2C9075C05E820E0E");

                entity.Property(e => e.PersonaId).HasColumnName("Persona_Id");

                entity.Property(e => e.PersonaApellido)
                    .HasColumnName("Persona_Apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonaEmail)
                    .HasColumnName("Persona_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonaFechaNacimiento)
                    .HasColumnName("Persona_Fecha_Nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.PersonaNombre)
                    .HasColumnName("Persona_Nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonaTelefono)
                    .HasColumnName("Persona_Telefono")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.ProductosId).HasColumnName("Productos_id");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_id");

                entity.Property(e => e.ProductosNombre)
                    .HasColumnName("Productos_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductosPrecio).HasColumnName("Productos_precio");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__Productos__Categ__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
