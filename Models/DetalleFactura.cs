namespace SistemaTallerAutomotriz.Models
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }

        public int IdFactura { get; set; }

        public int IdServicio { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }

        public virtual Factura? Factura { get; set; }

        public virtual Servicio? Servicio { get; set; }
    }
}