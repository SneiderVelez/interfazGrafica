namespace interfazGrafica
{
    partial class frmCategories
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
            this.gbCategorias = new System.Windows.Forms.GroupBox();
            this.btnVolver = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.dgCategories = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCategorias
            // 
            this.gbCategorias.Controls.Add(this.btnVolver);
            this.gbCategorias.Controls.Add(this.dtpFechaCreacion);
            this.gbCategorias.Controls.Add(this.btnAgregar);
            this.gbCategorias.Controls.Add(this.txtDescripcion);
            this.gbCategorias.Controls.Add(this.txtCategories);
            this.gbCategorias.Font = new System.Drawing.Font("Book Antiqua", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCategorias.ForeColor = System.Drawing.Color.Gray;
            this.gbCategorias.Location = new System.Drawing.Point(29, 14);
            this.gbCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCategorias.Name = "gbCategorias";
            this.gbCategorias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCategorias.Size = new System.Drawing.Size(501, 512);
            this.gbCategorias.TabIndex = 4;
            this.gbCategorias.TabStop = false;
            this.gbCategorias.Text = "Lista de categorias";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.OrangeRed;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Depth = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolver.ForeColor = System.Drawing.Color.LightGray;
            this.btnVolver.Location = new System.Drawing.Point(29, 431);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Primary = true;
            this.btnVolver.Size = new System.Drawing.Size(445, 44);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpFechaCreacion.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtpFechaCreacion.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCreacion.Location = new System.Drawing.Point(29, 287);
            this.dtpFechaCreacion.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(445, 45);
            this.dtpFechaCreacion.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.ForeColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Location = new System.Drawing.Point(29, 373);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Primary = true;
            this.btnAgregar.Size = new System.Drawing.Size(445, 44);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDescripcion.Location = new System.Drawing.Point(29, 187);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(445, 64);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Text = "Descripción";
            // 
            // txtCategories
            // 
            this.txtCategories.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategories.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCategories.Location = new System.Drawing.Point(29, 116);
            this.txtCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.Size = new System.Drawing.Size(445, 41);
            this.txtCategories.TabIndex = 0;
            this.txtCategories.Text = "Categorias";
            // 
            // dgCategories
            // 
            this.dgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nombre,
            this.Descripcion,
            this.FechaDeCreacion,
            this.btnBorrar});
            this.dgCategories.Location = new System.Drawing.Point(608, 34);
            this.dgCategories.Margin = new System.Windows.Forms.Padding(4);
            this.dgCategories.Name = "dgCategories";
            this.dgCategories.RowHeadersWidth = 51;
            this.dgCategories.Size = new System.Drawing.Size(597, 185);
            this.dgCategories.TabIndex = 5;
            this.dgCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCategories_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Categoria";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 125;
            // 
            // FechaDeCreacion
            // 
            this.FechaDeCreacion.HeaderText = "Fecha de creacion";
            this.FechaDeCreacion.MinimumWidth = 6;
            this.FechaDeCreacion.Name = "FechaDeCreacion";
            this.FechaDeCreacion.Width = 125;
            // 
            // btnBorrar
            // 
            this.btnBorrar.HeaderText = "Borrar";
            this.btnBorrar.MinimumWidth = 6;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Width = 125;
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1280, 554);
            this.Controls.Add(this.dgCategories);
            this.Controls.Add(this.gbCategorias);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCategories";
            this.Text = "Categorias";
            this.gbCategorias.ResumeLayout(false);
            this.gbCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCategorias;
        private MaterialSkin.Controls.MaterialRaisedButton btnAgregar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCategories;
        private System.Windows.Forms.DataGridView dgCategories;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private MaterialSkin.Controls.MaterialRaisedButton btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeCreacion;
        private System.Windows.Forms.DataGridViewButtonColumn btnBorrar;
    }
}