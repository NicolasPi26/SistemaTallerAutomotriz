using SistemaTallerAutomotriz.Data;
using SistemaTallerAutomotriz.Models;

namespace SistemaTallerAutomotriz.Views
{
    public partial class FormEmpleados : Form
    {
        private readonly TallerDbContext _context;
        private int idEmpleadoSeleccionado = 0;

        public FormEmpleados()
        {
            InitializeComponent();

            _context = new TallerDbContext();

            CargarCombos();
            CargarEmpleados();
            LimpiarCampos();
        }

        private void CargarCombos()
        {
            cmbCargo.Items.Clear();

            cmbCargo.Items.Add("Administrador");
            cmbCargo.Items.Add("Mecánico");
            cmbCargo.Items.Add("Técnico");
            cmbCargo.Items.Add("Recepcionista");
            cmbCargo.Items.Add("Jefe de Taller");

            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
        }

        private void CargarEmpleados()
        {
            try
            {
                var empleados = _context.Empleados
                    .Select(e => new
                    {
                        e.IdEmpleado,
                        e.Cedula,
                        e.Nombres,
                        e.Apellidos,
                        e.Telefono,
                        e.Cargo,
                        Estado = e.Estado
                            ? "Activo"
                            : "Inactivo"
                    })
                    .ToList();

                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = empleados;

                dgvEmpleados.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvEmpleados.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvEmpleados.ReadOnly = true;

                dgvEmpleados.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar empleados:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            idEmpleadoSeleccionado = 0;

            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();

            if (cmbCargo.Items.Count > 0)
                cmbCargo.SelectedIndex = 0;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;

            txtBuscar.Clear();

            txtCedula.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Ingrese la cédula.");
                txtCedula.Focus();
                return false;
            }

            if (txtCedula.Text.Trim().Length != 10)
            {
                MessageBox.Show(
                    "La cédula debe tener 10 dígitos.");
                txtCedula.Focus();
                return false;
            }

            if (!txtCedula.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                    "La cédula solo debe contener números.");
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

            if (cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el cargo.");
                cmbCargo.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado.");
                cmbEstado.Focus();
                return false;
            }

            return true;
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                string cedula =
                    txtCedula.Text.Trim();

                bool existe =
                    _context.Empleados.Any(e =>
                        e.Cedula == cedula);

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe un empleado con esa cédula.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Empleado empleado = new Empleado
                {
                    Cedula = cedula,
                    Nombres =
                        txtNombres.Text.Trim(),
                    Apellidos =
                        txtApellidos.Text.Trim(),
                    Telefono =
                        txtTelefono.Text.Trim(),
                    Cargo =
                        cmbCargo.SelectedItem?.ToString()
                        ?? "",
                    Estado =
                        cmbEstado.SelectedItem?.ToString()
                        == "Activo"
                };

                _context.Empleados.Add(empleado);
                _context.SaveChanges();

                MessageBox.Show(
                    "Empleado registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvEmpleados_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvEmpleados.Rows[e.RowIndex];

            idEmpleadoSeleccionado =
                Convert.ToInt32(
                    fila.Cells["IdEmpleado"].Value);

            txtCedula.Text =
                fila.Cells["Cedula"].Value?.ToString();

            txtNombres.Text =
                fila.Cells["Nombres"].Value?.ToString();

            txtApellidos.Text =
                fila.Cells["Apellidos"].Value?.ToString();

            txtTelefono.Text =
                fila.Cells["Telefono"].Value?.ToString();

            cmbCargo.SelectedItem =
                fila.Cells["Cargo"].Value?.ToString();

            cmbEstado.SelectedItem =
                fila.Cells["Estado"].Value?.ToString();
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idEmpleadoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un empleado.");
                    return;
                }

                if (!ValidarCampos())
                    return;

                string cedula =
                    txtCedula.Text.Trim();

                bool existe =
                    _context.Empleados.Any(e =>
                        e.Cedula == cedula &&
                        e.IdEmpleado !=
                        idEmpleadoSeleccionado);

                if (existe)
                {
                    MessageBox.Show(
                        "La cédula ya pertenece a otro empleado.");
                    return;
                }

                Empleado? empleado =
                    _context.Empleados.Find(
                        idEmpleadoSeleccionado);

                if (empleado == null)
                {
                    MessageBox.Show(
                        "Empleado no encontrado.");
                    return;
                }

                empleado.Cedula = cedula;

                empleado.Nombres =
                    txtNombres.Text.Trim();

                empleado.Apellidos =
                    txtApellidos.Text.Trim();

                empleado.Telefono =
                    txtTelefono.Text.Trim();

                empleado.Cargo =
                    cmbCargo.SelectedItem?.ToString()
                    ?? "";

                empleado.Estado =
                    cmbEstado.SelectedItem?.ToString()
                    == "Activo";

                _context.SaveChanges();

                MessageBox.Show(
                    "Empleado actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idEmpleadoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un empleado.");
                    return;
                }

                bool tieneFacturas =
                    _context.Facturas.Any(f =>
                        f.IdEmpleado ==
                        idEmpleadoSeleccionado);

                if (tieneFacturas)
                {
                    MessageBox.Show(
                        "No se puede eliminar este empleado porque tiene facturas registradas.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Está seguro de eliminar este empleado?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Empleado? empleado =
                    _context.Empleados.Find(
                        idEmpleadoSeleccionado);

                if (empleado == null)
                    return;

                _context.Empleados.Remove(empleado);
                _context.SaveChanges();

                MessageBox.Show(
                    "Empleado eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string texto =
                    txtBuscar.Text.Trim().ToLower();

                var empleados =
                    _context.Empleados
                    .Where(e =>
                        e.Cedula.ToLower()
                            .Contains(texto) ||
                        e.Nombres.ToLower()
                            .Contains(texto) ||
                        e.Apellidos.ToLower()
                            .Contains(texto) ||
                        e.Cargo.ToLower()
                            .Contains(texto))
                    .Select(e => new
                    {
                        e.IdEmpleado,
                        e.Cedula,
                        e.Nombres,
                        e.Apellidos,
                        e.Telefono,
                        e.Cargo,
                        Estado = e.Estado
                            ? "Activo"
                            : "Inactivo"
                    })
                    .ToList();

                dgvEmpleados.DataSource =
                    empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
