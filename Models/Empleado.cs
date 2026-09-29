namespace SistemaTallerAutomotriz.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Cedula { get; set; } = "";

        public string Nombres { get; set; } = "";

        public string Apellidos { get; set; } = "";

        public string? Telefono { get; set; }

        public string Cargo { get; set; } = "";

        public bool Estado { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
            = new List<Factura>();
    }
}