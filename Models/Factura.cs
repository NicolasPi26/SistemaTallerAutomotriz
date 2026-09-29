namespace SistemaTallerAutomotriz.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }

        public string NumeroFactura { get; set; } = "";

        public DateTime Fecha { get; set; }

        public int IdVehiculo { get; set; }

        public int IdEmpleado { get; set; }

        public decimal Subtotal { get; set; }

        public decimal IVA { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = "EMITIDA";

        public virtual Vehiculo? Vehiculo { get; set; }

        public virtual Empleado? Empleado { get; set; }

        public virtual ICollection<DetalleFactura> Detalles { get; set; }
            = new List<DetalleFactura>();
    }
}