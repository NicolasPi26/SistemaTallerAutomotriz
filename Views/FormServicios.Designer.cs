namespace SistemaTallerAutomotriz.Views
{
    partial class FormServicios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblDuracion = new Label();
            nudDuracion = new NumericUpDown();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvServicios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 16);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 55);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 51);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(400, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(20, 90);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(120, 86);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 5;
            nudPrecio.Minimum = 0;
            nudPrecio.Maximum = 10000;
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Increment = 0.50M;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(260, 90);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(93, 15);
            lblDuracion.TabIndex = 6;
            lblDuracion.Text = "Duración (min)";
            // 
            // nudDuracion
            // 
            nudDuracion.Location = new Point(360, 86);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(120, 23);
            nudDuracion.TabIndex = 7;
            nudDuracion.Minimum = 1;
            nudDuracion.Maximum = 1440;
            nudDuracion.Value = 60;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 125);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 8;
            lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(120, 121);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 9;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(540, 16);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 27);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(540, 51);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 27);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(540, 86);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 27);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(540, 121);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 27);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += this.btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(640, 16);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 27);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += this.btnLimpiar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 165);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(500, 23);
            txtBuscar.TabIndex = 15;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(540, 163);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 27);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += this.btnBuscar_Click;
            // 
            // dgvServicios
            // 
            dgvServicios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServicios.Location = new Point(20, 200);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.Size = new Size(700, 420);
            dgvServicios.TabIndex = 17;
            dgvServicios.CellClick += this.dgvServicios_CellClick;
            // 
            // FormServicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 640);
            Controls.Add(dgvServicios);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(nudDuracion);
            Controls.Add(lblDuracion);
            Controls.Add(nudPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "FormServicios";
            Text = "FormServicios";
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblDuracion;
        private NumericUpDown nudDuracion;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvServicios;
    }
}
