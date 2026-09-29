using SistemaTallerAutomotriz.Data;
using SistemaTallerAutomotriz.Models;

namespace SistemaTallerAutomotriz.Views
{
    public partial class FormVehiculos : Form
    {
        private readonly TallerDbContext _context;
        private int idVehiculoSeleccionado = 0;

        public FormVehiculos()
        {
            InitializeComponent();

            _context = new TallerDbContext();

            CargarClientes();
            CargarVehiculos();
            LimpiarCampos();
        }

        // =========================
        // CARGAR CLIENTES
        // =========================
        private void CargarClientes()
        {
            try
            {
                var clientes = _context.Clientes
                    .OrderBy(c => c.Apellidos)
                    .ThenBy(c => c.Nombres)
                    .ToList();

                cmbCliente.DataSource = null;
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "Nombres";
                cmbCliente.ValueMember = "IdCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar clientes:\n" + ex.Message);
            }
        }

        // =========================
        // CARGAR VEHÍCULOS
        // =========================
        private void CargarVehiculos()
        {
            try
            {
                var vehiculos = _context.Vehiculos
                    .Select(v => new
                    {
                        v.IdVehiculo,
                        v.Placa,
                        v.Marca,
                        v.Modelo,
                        v.Anio,
                        v.Color,
                        IdCliente = v.IdCliente,
                        Cliente = v.Cliente != null
                            ? v.Cliente.Nombres + " " +
                              v.Cliente.Apellidos
                            : ""
                    })
                    .ToList();

                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource = vehiculos;

                dgvVehiculos.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvVehiculos.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvVehiculos.ReadOnly = true;

                dgvVehiculos.AllowUserToAddRows = false;

                if (dgvVehiculos.Columns["IdCliente"] != null)
                    dgvVehiculos.Columns["IdCliente"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar vehículos:\n" + ex.Message);
            }
        }

        // =========================
        // LIMPIAR
        // =========================
        private void LimpiarCampos()
        {
            idVehiculoSeleccionado = 0;

            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            nudAnio.Value = 2026;
            txtColor.Clear();

            if (cmbCliente.Items.Count > 0)
                cmbCliente.SelectedIndex = 0;

            txtPlaca.Focus();
        }

        // =========================
        // VALIDAR
        // =========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Ingrese la placa.");
                txtPlaca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Ingrese la marca.");
                txtMarca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo.");
                txtModelo.Focus();
                return false;
            }

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                cmbCliente.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // NUEVO
        // =========================
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                string placa =
                    txtPlaca.Text.Trim().ToUpper();

                bool existe =
                    _context.Vehiculos.Any(v =>
                        v.Placa == placa);

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe un vehículo con esa placa.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Vehiculo vehiculo = new Vehiculo
                {
                    Placa = placa,
                    Marca = txtMarca.Text.Trim(),
                    Modelo = txtModelo.Text.Trim(),
                    Anio = (int)nudAnio.Value,
                    Color = txtColor.Text.Trim(),
                    IdCliente = Convert.ToInt32(
                        cmbCliente.SelectedValue)
                };

                _context.Vehiculos.Add(vehiculo);
                _context.SaveChanges();

                MessageBox.Show(
                    "Vehículo registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // SELECCIONAR
        // =========================
        private void dgvVehiculos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvVehiculos.Rows[e.RowIndex];

            idVehiculoSeleccionado =
                Convert.ToInt32(
                    fila.Cells["IdVehiculo"].Value);

            txtPlaca.Text =
                fila.Cells["Placa"].Value?.ToString();

            txtMarca.Text =
                fila.Cells["Marca"].Value?.ToString();

            txtModelo.Text =
                fila.Cells["Modelo"].Value?.ToString();

            nudAnio.Value =
                Convert.ToDecimal(
                    fila.Cells["Anio"].Value);

            txtColor.Text =
                fila.Cells["Color"].Value?.ToString();

            int idCliente =
                Convert.ToInt32(
                    fila.Cells["IdCliente"].Value);

            cmbCliente.SelectedValue = idCliente;
        }

        // =========================
        // ACTUALIZAR
        // =========================
        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idVehiculoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un vehículo.");
                    return;
                }

                if (!ValidarCampos())
                    return;

                string placa =
                    txtPlaca.Text.Trim().ToUpper();

                bool existe =
                    _context.Vehiculos.Any(v =>
                        v.Placa == placa &&
                        v.IdVehiculo !=
                        idVehiculoSeleccionado);

                if (existe)
                {
                    MessageBox.Show(
                        "La placa ya pertenece a otro vehículo.");
                    return;
                }

                Vehiculo? vehiculo =
                    _context.Vehiculos.Find(
                        idVehiculoSeleccionado);

                if (vehiculo == null)
                {
                    MessageBox.Show(
                        "Vehículo no encontrado.");
                    return;
                }

                vehiculo.Placa = placa;
                vehiculo.Marca =
                    txtMarca.Text.Trim();
                vehiculo.Modelo =
                    txtModelo.Text.Trim();
                vehiculo.Anio =
                    (int)nudAnio.Value;
                vehiculo.Color =
                    txtColor.Text.Trim();
                vehiculo.IdCliente =
                    Convert.ToInt32(
                        cmbCliente.SelectedValue);

                _context.SaveChanges();

                MessageBox.Show(
                    "Vehículo actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar:\n" + ex.Message);
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idVehiculoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un vehículo.");
                    return;
                }

                bool tieneFacturas =
                    _context.Facturas.Any(f =>
                        f.IdVehiculo ==
                        idVehiculoSeleccionado);

                if (tieneFacturas)
                {
                    MessageBox.Show(
                        "No se puede eliminar este vehículo porque tiene facturas registradas.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Está seguro de eliminar este vehículo?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Vehiculo? vehiculo =
                    _context.Vehiculos.Find(
                        idVehiculoSeleccionado);

                if (vehiculo == null)
                    return;

                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();

                MessageBox.Show(
                    "Vehículo eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" + ex.Message);
            }
        }

        // =========================
        // BUSCAR
        // =========================
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string texto =
                    txtBuscar.Text.Trim().ToUpper();

                var vehiculos =
                    _context.Vehiculos
                    .Where(v =>
                        v.Placa.Contains(texto) ||
                        v.Marca.Contains(texto) ||
                        v.Modelo.Contains(texto))
                    .Select(v => new
                    {
                        v.IdVehiculo,
                        v.Placa,
                        v.Marca,
                        v.Modelo,
                        v.Anio,
                        v.Color,
                        IdCliente = v.IdCliente,
                        Cliente = v.Cliente != null
                            ? v.Cliente.Nombres + " " +
                              v.Cliente.Apellidos
                            : ""
                    })
                    .ToList();

                dgvVehiculos.DataSource = vehiculos;

                if (dgvVehiculos.Columns["IdCliente"] != null)
                    dgvVehiculos.Columns["IdCliente"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar:\n" + ex.Message);
            }
        }
    }
}
