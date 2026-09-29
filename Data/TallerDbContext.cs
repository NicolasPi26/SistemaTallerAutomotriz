using Microsoft.EntityFrameworkCore;
using SistemaTallerAutomotriz.Models;

namespace SistemaTallerAutomotriz.Data
{
    public class TallerDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conexion =
                    "Server=localhost;" +
                    "Port=3306;" +
                    "Database=DB_TallerAutomotriz;" +
                    "User=root;" +
                    "Password=Nicopi2608;";

                optionsBuilder.UseMySql(
                    conexion,
                    ServerVersion.AutoDetect(conexion)
                );
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasIndex(e => e.Cedula)
                    .IsUnique();
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasIndex(e => e.Placa)
                    .IsUnique();

                entity.HasOne(e => e.Cliente)
                    .WithMany(e => e.Vehiculos)
                    .HasForeignKey(e => e.IdCliente);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.Property(e => e.Precio)
                    .HasPrecision(10, 2);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasIndex(e => e.Cedula)
                    .IsUnique();
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10, 2);

                entity.Property(e => e.IVA)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Total)
                    .HasPrecision(10, 2);

                entity.HasOne(e => e.Vehiculo)
                    .WithMany(e => e.Facturas)
                    .HasForeignKey(e => e.IdVehiculo);

                entity.HasOne(e => e.Empleado)
                    .WithMany(e => e.Facturas)
                    .HasForeignKey(e => e.IdEmpleado);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.Property(e => e.PrecioUnitario)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10, 2);

                entity.HasOne(e => e.Factura)
                    .WithMany(e => e.Detalles)
                    .HasForeignKey(e => e.IdFactura);

                entity.HasOne(e => e.Servicio)
                    .WithMany(e => e.DetalleFacturas)
                    .HasForeignKey(e => e.IdServicio);
            });
        }
    }
}