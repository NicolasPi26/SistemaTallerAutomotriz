namespace SistemaTallerAutomotriz.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }

        public string Placa { get; set; } = "";

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public int Anio { get; set; }

        public string? Color { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente? Cliente { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
            = new List<Factura>();
    }
}
