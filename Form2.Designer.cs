namespace interfazGrafica
{
    partial class frmList
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
            this.gbTareas = new System.Windows.Forms.GroupBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.btnCategories = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgTaskApp = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbTareas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskApp)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTareas
            // 
            this.gbTareas.Controls.Add(this.cboCategoria);
            this.gbTareas.Controls.Add(this.btnCategories);
            this.gbTareas.Controls.Add(this.cboEstado);
            this.gbTareas.Controls.Add(this.btnAgregar);
            this.gbTareas.Controls.Add(this.txtDescripcion);
            this.gbTareas.Controls.Add(this.txtName);
            this.gbTareas.Font = new System.Drawing.Font("Book Antiqua", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTareas.ForeColor = System.Drawing.Color.Gray;
            this.gbTareas.Location = new System.Drawing.Point(12, 33);
            this.gbTareas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTareas.Name = "gbTareas";
            this.gbTareas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTareas.Size = new System.Drawing.Size(501, 459);
            this.gbTareas.TabIndex = 3;
            this.gbTareas.TabStop = false;
            this.gbTareas.Text = "Lista de tareas";
            // 
            // cboCategoria
            // 
            this.cboCategoria.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(29, 253);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(445, 40);
            this.cboCategoria.TabIndex = 5;
            this.cboCategoria.Text = "Categorias";
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.Depth = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategories.ForeColor = System.Drawing.Color.LightGray;
            this.btnCategories.Location = new System.Drawing.Point(29, 383);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategories.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Primary = true;
            this.btnCategories.Size = new System.Drawing.Size(445, 45);
            this.btnCategories.TabIndex = 4;
            this.btnCategories.Text = "Categorias";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(29, 191);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(445, 40);
            this.cboEstado.TabIndex = 2;
            this.cboEstado.Text = "Estado";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.ForeColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Location = new System.Drawing.Point(29, 318);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Primary = true;
            this.btnAgregar.Size = new System.Drawing.Size(445, 45);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDescripcion.Location = new System.Drawing.Point(29, 131);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(445, 41);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Text = "Descripción";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtName.Location = new System.Drawing.Point(29, 73);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(445, 41);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Nombre";
            // 
            // dgTaskApp
            // 
            this.dgTaskApp.AllowUserToOrderColumns = true;
            this.dgTaskApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaskApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.tarea,
            this.descripcion,
            this.estado,
            this.categoria,
            this.btnEditar,
            this.btnBorrar});
            this.dgTaskApp.Location = new System.Drawing.Point(546, 67);
            this.dgTaskApp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgTaskApp.Name = "dgTaskApp";
            this.dgTaskApp.RowHeadersWidth = 51;
            this.dgTaskApp.RowTemplate.Height = 24;
            this.dgTaskApp.Size = new System.Drawing.Size(793, 438);
            this.dgTaskApp.TabIndex = 4;
            this.dgTaskApp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaskApp_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // tarea
            // 
            this.tarea.HeaderText = "Tarea";
            this.tarea.MinimumWidth = 6;
            this.tarea.Name = "tarea";
            this.tarea.Width = 125;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 125;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.Width = 125;
            // 
            // categoria
            // 
            this.categoria.HeaderText = "Categoria";
            this.categoria.MinimumWidth = 6;
            this.categoria.Name = "categoria";
            this.categoria.Width = 125;
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "Editar";
            this.btnEditar.MinimumWidth = 6;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Width = 125;
            // 
            // btnBorrar
            // 
            this.btnBorrar.HeaderText = "Borrar";
            this.btnBorrar.MinimumWidth = 6;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Width = 125;
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1351, 516);
            this.Controls.Add(this.dgTaskApp);
            this.Controls.Add(this.gbTareas);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmList";
            this.Text = "TareasForm";
            this.Load += new System.EventHandler(this.frmList_Load);
            this.gbTareas.ResumeLayout(false);
            this.gbTareas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTareas;
        private System.Windows.Forms.DataGridView dgTaskApp;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox txtDescripcion;
        private MaterialSkin.Controls.MaterialRaisedButton btnAgregar;
        private MaterialSkin.Controls.MaterialRaisedButton btnCategories;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnBorrar;
    }
}