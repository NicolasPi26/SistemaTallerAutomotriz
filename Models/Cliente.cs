namespace SistemaTallerAutomotriz.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Cedula { get; set; } = "";

        public string Nombres { get; set; } = "";

        public string Apellidos { get; set; } = "";

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
            = new List<Vehiculo>();
    }
}