namespace SistemaTallerAutomotriz.Views
{
    partial class FormVehiculos
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblAnio = new Label();
            nudAnio = new NumericUpDown();
            lblColor = new Label();
            txtColor = new TextBox();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvVehiculos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(20, 20);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(34, 15);
            lblPlaca.TabIndex = 0;
            lblPlaca.Text = "Placa";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(100, 16);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(200, 23);
            txtPlaca.TabIndex = 1;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(20, 55);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(39, 15);
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(100, 51);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(200, 23);
            txtMarca.TabIndex = 3;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(20, 90);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(48, 15);
            lblModelo.TabIndex = 4;
            lblModelo.Text = "Modelo";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(100, 86);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(200, 23);
            txtModelo.TabIndex = 5;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(20, 125);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(29, 15);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(100, 121);
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(120, 23);
            nudAnio.TabIndex = 7;
            nudAnio.Minimum = 1950;
            nudAnio.Maximum = 2100;
            nudAnio.Value = 2026;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(20, 160);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(36, 15);
            lblColor.TabIndex = 8;
            lblColor.Text = "Color";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(100, 156);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(200, 23);
            txtColor.TabIndex = 9;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 195);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 10;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(100, 191);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(200, 23);
            cmbCliente.TabIndex = 11;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(330, 16);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 27);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(330, 51);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 27);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(330, 86);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 27);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(330, 121);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 27);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += this.btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(330, 156);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 27);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += this.btnNuevo_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 230);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(280, 23);
            txtBuscar.TabIndex = 17;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(330, 228);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 27);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += this.btnBuscar_Click;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVehiculos.Location = new Point(20, 270);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.Size = new Size(680, 520);
            dgvVehiculos.TabIndex = 19;
            dgvVehiculos.CellClick += this.dgvVehiculos_CellClick;
            // 
            // FormVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 820);
            Controls.Add(dgvVehiculos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Controls.Add(txtColor);
            Controls.Add(lblColor);
            Controls.Add(nudAnio);
            Controls.Add(lblAnio);
            Controls.Add(txtModelo);
            Controls.Add(lblModelo);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(txtPlaca);
            Controls.Add(lblPlaca);
            Name = "FormVehiculos";
            Text = "FormVehiculos";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlaca;
        private TextBox txtPlaca;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblAnio;
        private NumericUpDown nudAnio;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvVehiculos;
    }
}
