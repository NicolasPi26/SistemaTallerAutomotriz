using SistemaTallerAutomotriz.Data;
using SistemaTallerAutomotriz.Models;

namespace SistemaTallerAutomotriz.Views
{
    public partial class FormServicios : Form
    {
        private readonly TallerDbContext _context;
        private int idServicioSeleccionado = 0;

        public FormServicios()
        {
            InitializeComponent();

            _context = new TallerDbContext();

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

            CargarServicios();
            LimpiarCampos();
        }

        private void CargarServicios()
        {
            try
            {
                var servicios = _context.Servicios
                    .Select(s => new
                    {
                        s.IdServicio,
                        s.Nombre,
                        s.Descripcion,
                        s.Precio,
                        s.DuracionEstimada,
                        Estado = s.Estado ? "Activo" : "Inactivo"
                    })
                    .ToList();

                dgvServicios.DataSource = null;
                dgvServicios.DataSource = servicios;

                dgvServicios.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvServicios.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvServicios.ReadOnly = true;

                dgvServicios.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar servicios:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            idServicioSeleccionado = 0;

            txtNombre.Clear();
            txtDescripcion.Clear();

            nudPrecio.Value = 0;
            nudDuracion.Value = 60;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;

            txtBuscar.Clear();

            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del servicio.");
                txtNombre.Focus();
                return false;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show("Ingrese un precio válido.");
                nudPrecio.Focus();
                return false;
            }

            if (nudDuracion.Value <= 0)
            {
                MessageBox.Show("Ingrese una duración válida.");
                nudDuracion.Focus();
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

                string nombre =
                    txtNombre.Text.Trim();

                bool existe =
                    _context.Servicios.Any(s =>
                        s.Nombre.ToLower() ==
                        nombre.ToLower());

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe un servicio con ese nombre.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Servicio servicio = new Servicio
                {
                    Nombre = nombre,
                    Descripcion =
                        txtDescripcion.Text.Trim(),
                    Precio = nudPrecio.Value,
                    DuracionEstimada =
                        (int)nudDuracion.Value,
                    Estado =
                        cmbEstado.SelectedItem?.ToString()
                        == "Activo"
                };

                _context.Servicios.Add(servicio);
                _context.SaveChanges();

                MessageBox.Show(
                    "Servicio registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarServicios();
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

        private void dgvServicios_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvServicios.Rows[e.RowIndex];

            idServicioSeleccionado =
                Convert.ToInt32(
                    fila.Cells["IdServicio"].Value);

            txtNombre.Text =
                fila.Cells["Nombre"].Value?.ToString();

            txtDescripcion.Text =
                fila.Cells["Descripcion"].Value?.ToString();

            nudPrecio.Value =
                Convert.ToDecimal(
                    fila.Cells["Precio"].Value);

            nudDuracion.Value =
                Convert.ToDecimal(
                    fila.Cells["DuracionEstimada"].Value);

            string estado =
                fila.Cells["Estado"].Value?.ToString()
                ?? "Activo";

            cmbEstado.SelectedItem = estado;
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idServicioSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un servicio.");
                    return;
                }

                if (!ValidarCampos())
                    return;

                string nombre =
                    txtNombre.Text.Trim();

                bool existe =
                    _context.Servicios.Any(s =>
                        s.Nombre.ToLower() ==
                        nombre.ToLower() &&
                        s.IdServicio !=
                        idServicioSeleccionado);

                if (existe)
                {
                    MessageBox.Show(
                        "El nombre ya pertenece a otro servicio.");
                    return;
                }

                Servicio? servicio =
                    _context.Servicios.Find(
                        idServicioSeleccionado);

                if (servicio == null)
                {
                    MessageBox.Show(
                        "Servicio no encontrado.");
                    return;
                }

                servicio.Nombre = nombre;

                servicio.Descripcion =
                    txtDescripcion.Text.Trim();

                servicio.Precio =
                    nudPrecio.Value;

                servicio.DuracionEstimada =
                    (int)nudDuracion.Value;

                servicio.Estado =
                    cmbEstado.SelectedItem?.ToString()
                    == "Activo";

                _context.SaveChanges();

                MessageBox.Show(
                    "Servicio actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarServicios();
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

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idServicioSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un servicio.");
                    return;
                }

                bool tieneDetalles =
                    _context.DetalleFacturas.Any(d =>
                        d.IdServicio ==
                        idServicioSeleccionado);

                if (tieneDetalles)
                {
                    MessageBox.Show(
                        "No se puede eliminar este servicio porque ya está registrado en una factura.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Está seguro de eliminar este servicio?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Servicio? servicio =
                    _context.Servicios.Find(
                        idServicioSeleccionado);

                if (servicio == null)
                    return;

                _context.Servicios.Remove(servicio);
                _context.SaveChanges();

                MessageBox.Show(
                    "Servicio eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarServicios();
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

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string texto =
                    txtBuscar.Text.Trim().ToLower();

                var servicios =
                    _context.Servicios
                    .Where(s =>
                        s.Nombre.ToLower()
                            .Contains(texto) ||
                        (s.Descripcion != null &&
                         s.Descripcion.ToLower()
                            .Contains(texto)))
                    .Select(s => new
                    {
                        s.IdServicio,
                        s.Nombre,
                        s.Descripcion,
                        s.Precio,
                        s.DuracionEstimada,
                        Estado = s.Estado
                            ? "Activo"
                            : "Inactivo"
                    })
                    .ToList();

                dgvServicios.DataSource = servicios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar:\n" + ex.Message,
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
