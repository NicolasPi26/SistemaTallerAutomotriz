using SistemaTallerAutomotriz.Data;
using SistemaTallerAutomotriz.Models;

namespace SistemaTallerAutomotriz.Views
{
    public partial class FormClientes : Form
    {
        private readonly TallerDbContext _context;
        private int idClienteSeleccionado = 0;

        public FormClientes()
        {
            InitializeComponent();

            _context = new TallerDbContext();

            CargarClientes();
            LimpiarCampos();
        }

        // =========================
        // CARGAR CLIENTES
        // =========================
        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;

                dgvClientes.DataSource = _context.Clientes
                    .Select(c => new
                    {
                        c.IdCliente,
                        c.Cedula,
                        c.Nombres,
                        c.Apellidos,
                        c.Telefono,
                        c.Correo,
                        c.Direccion
                    })
                    .ToList();

                dgvClientes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvClientes.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvClientes.ReadOnly = true;

                dgvClientes.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar clientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // LIMPIAR
        // =========================
        private void LimpiarCampos()
        {
            idClienteSeleccionado = 0;

            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            txtCedula.Focus();
        }

        // =========================
        // VALIDAR
        // =========================
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Ingrese la cédula.");
                txtCedula.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese los nombres.");
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos.");
                txtApellidos.Focus();
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

                bool existe = _context.Clientes
                    .Any(c => c.Cedula == txtCedula.Text.Trim());

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe un cliente con esa cédula.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Cliente cliente = new Cliente
                {
                    Cedula = txtCedula.Text.Trim(),
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                MessageBox.Show(
                    "Cliente registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
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
        // SELECCIONAR CLIENTE
        // =========================
        private void dgvClientes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvClientes.Rows[e.RowIndex];

            idClienteSeleccionado =
                Convert.ToInt32(fila.Cells["IdCliente"].Value);

            txtCedula.Text =
                fila.Cells["Cedula"].Value?.ToString();

            txtNombres.Text =
                fila.Cells["Nombres"].Value?.ToString();

            txtApellidos.Text =
                fila.Cells["Apellidos"].Value?.ToString();

            txtTelefono.Text =
                fila.Cells["Telefono"].Value?.ToString();

            txtCorreo.Text =
                fila.Cells["Correo"].Value?.ToString();

            txtDireccion.Text =
                fila.Cells["Direccion"].Value?.ToString();
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
                if (idClienteSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un cliente para actualizar.");

                    return;
                }

                if (!ValidarCampos())
                    return;

                Cliente? cliente =
                    _context.Clientes.Find(
                        idClienteSeleccionado);

                if (cliente == null)
                {
                    MessageBox.Show(
                        "Cliente no encontrado.");

                    return;
                }

                bool cedulaExiste =
                    _context.Clientes.Any(c =>
                        c.Cedula == txtCedula.Text.Trim() &&
                        c.IdCliente != idClienteSeleccionado);

                if (cedulaExiste)
                {
                    MessageBox.Show(
                        "La cédula ya pertenece a otro cliente.");

                    return;
                }

                cliente.Cedula =
                    txtCedula.Text.Trim();

                cliente.Nombres =
                    txtNombres.Text.Trim();

                cliente.Apellidos =
                    txtApellidos.Text.Trim();

                cliente.Telefono =
                    txtTelefono.Text.Trim();

                cliente.Correo =
                    txtCorreo.Text.Trim();

                cliente.Direccion =
                    txtDireccion.Text.Trim();

                _context.SaveChanges();

                MessageBox.Show(
                    "Cliente actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                if (idClienteSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un cliente para eliminar.");

                    return;
                }

                bool tieneVehiculos =
                    _context.Vehiculos.Any(v =>
                        v.IdCliente == idClienteSeleccionado);

                if (tieneVehiculos)
                {
                    MessageBox.Show(
                        "No se puede eliminar este cliente porque tiene vehículos registrados.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Está seguro de eliminar este cliente?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Cliente? cliente =
                    _context.Clientes.Find(
                        idClienteSeleccionado);

                if (cliente == null)
                    return;

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();

                MessageBox.Show(
                    "Cliente eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    txtBuscar.Text.Trim();

                var clientes =
                    _context.Clientes
                    .Where(c =>
                        c.Cedula.Contains(texto) ||
                        c.Nombres.Contains(texto) ||
                        c.Apellidos.Contains(texto))
                    .Select(c => new
                    {
                        c.IdCliente,
                        c.Cedula,
                        c.Nombres,
                        c.Apellidos,
                        c.Telefono,
                        c.Correo,
                        c.Direccion
                    })
                    .ToList();

                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar:\n" + ex.Message);
            }
        }
    }
}
