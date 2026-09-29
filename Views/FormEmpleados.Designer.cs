namespace SistemaTallerAutomotriz.Views
{
    partial class FormEmpleados
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
            lblCedula = new Label();
            txtCedula = new TextBox();
            lblNombres = new Label();
            txtNombres = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCargo = new Label();
            cmbCargo = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvEmpleados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(20, 20);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(44, 15);
            lblCedula.TabIndex = 0;
            lblCedula.Text = "Cédula";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(100, 16);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(200, 23);
            txtCedula.TabIndex = 1;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(20, 55);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(56, 15);
            lblNombres.TabIndex = 2;
            lblNombres.Text = "Nombres";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(100, 51);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(200, 23);
            txtNombres.TabIndex = 3;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(20, 90);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 4;
            lblApellidos.Text = "Apellidos";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(100, 86);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(200, 23);
            txtApellidos.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 125);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(100, 121);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(320, 20);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(38, 15);
            lblCargo.TabIndex = 8;
            lblCargo.Text = "Cargo";
            // 
            // cmbCargo
            // 
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.Location = new Point(390, 16);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(200, 23);
            cmbCargo.TabIndex = 9;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(320, 55);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(390, 51);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 11;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(320, 90);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 27);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(410, 90);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 27);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(500, 90);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 27);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(590, 90);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 27);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += this.btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(680, 90);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 27);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += this.btnLimpiar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 165);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(580, 23);
            txtBuscar.TabIndex = 17;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(610, 163);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 27);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += this.btnBuscar_Click;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmpleados.Location = new Point(20, 200);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.Size = new Size(740, 420);
            dgvEmpleados.TabIndex = 19;
            dgvEmpleados.CellClick += this.dgvEmpleados_CellClick;
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 640);
            Controls.Add(dgvEmpleados);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(cmbCargo);
            Controls.Add(lblCargo);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(lblApellidos);
            Controls.Add(txtNombres);
            Controls.Add(lblNombres);
            Controls.Add(txtCedula);
            Controls.Add(lblCedula);
            Name = "FormEmpleados";
            Text = "FormEmpleados";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCedula;
        private TextBox txtCedula;
        private Label lblNombres;
        private TextBox txtNombres;
        private Label lblApellidos;
        private TextBox txtApellidos;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCargo;
        private ComboBox cmbCargo;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvEmpleados;
    }
}
