using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace interfazGrafica
{
    public partial class frmList : Form
    {
        public string usuario;
        public string contraseña;

        // Constructor
        public frmList(string usuarioRecibido, string contraseñaRecibida)
        {
            InitializeComponent();
            usuario = usuarioRecibido;
            contraseña = contraseñaRecibida;
        }

        public class Estado
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        public class Categoria
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El campo 'Tarea' es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.");
                return false;
            }

            if (cboEstado.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un estado.");
                return false;
            }

            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoria.");
                return false;
            }

            return true;
        }
      
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query;

            // Si se está editando, actualiza la tarea
            if (txtName.Tag != null)
            {
                int tareaId;
                if (!int.TryParse(txtName.Tag.ToString(), out tareaId))
                {
                    MessageBox.Show("Error: No se pudo obtener el ID de la tarea.");
                    return;
                }

                query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, estadoId = @estado, categoriaId = @categoriaId WHERE ID = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@titulo", txtName.Text);
                            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                            cmd.Parameters.AddWithValue("@estado", ((Estado)cboEstado.SelectedItem).ID);
                            cmd.Parameters.AddWithValue("@categoriaId", ((Categoria)cboCategoria.SelectedItem).ID);
                            cmd.Parameters.AddWithValue("@id", tareaId);

                            cmd.ExecuteNonQuery();
                        }

                        // Actualizar la fila en el DataGridView
                        foreach (DataGridViewRow row in dgTaskApp.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["ID"].Value) == tareaId)
                            {
                                row.Cells["Tarea"].Value = txtName.Text;
                                row.Cells["Descripcion"].Value = txtDescripcion.Text;
                                row.Cells["Estado"].Value = cboEstado.SelectedItem.ToString();
                                row.Cells["Categoria"].Value = cboCategoria.SelectedItem.ToString();
                                break;
                            }
                        }

                        MessageBox.Show("Tarea actualizada correctamente.");
                        txtName.Tag = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar tarea: " + ex.Message);
                    }
                }
            }
            else
            {
                query = "INSERT INTO Tareas (titulo, descripcion, estadoId, categoriaId, usuarioId) VALUES (@titulo, @descripcion, @estado, @categoriaId, @usuarioId)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@titulo", txtName.Text);
                            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                            cmd.Parameters.AddWithValue("@estado", ((Estado)cboEstado.SelectedItem).ID);
                            cmd.Parameters.AddWithValue("@categoriaId", ((Categoria)cboCategoria.SelectedItem).ID);
                            cmd.Parameters.AddWithValue("@usuarioId", ObtenerUsuarioID(usuario));

                            cmd.ExecuteNonQuery();
                        }

                        dgTaskApp.Rows.Add(0, txtName.Text, txtDescripcion.Text, cboEstado.SelectedItem.ToString(), cboCategoria.SelectedItem.ToString(), "Editar", "Borrar");

                        txtName.Clear();
                        txtDescripcion.Clear();
                        cboEstado.SelectedIndex = -1;
                        cboCategoria.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar tarea: " + ex.Message);
                    }
                }
            }
        }

        private int ObtenerUsuarioID(string nombreUsuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query = "SELECT ID FROM Usuarios WHERE nombreUsuario = @nombre";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void dgTaskApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea el encabezado
            if (e.RowIndex < 0) return;

            DataGridViewRow filaSeleccionada = dgTaskApp.Rows[e.RowIndex];

            // Si se presiona el botón "Editar"
            if (e.ColumnIndex == dgTaskApp.Columns["btnEditar"].Index)
            {
                txtName.Text = filaSeleccionada.Cells["Tarea"].Value.ToString();
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();

                string estadoNombre = filaSeleccionada.Cells["Estado"].Value.ToString();
                foreach (Estado estado in cboEstado.Items)
                {
                    if (estado.Nombre == estadoNombre)
                    {
                        cboEstado.SelectedItem = estado;
                        break;
                    }
                }

                string categoriaNombre = filaSeleccionada.Cells["Categoria"].Value.ToString();
                foreach (Categoria categoria in cboCategoria.Items)
                {
                    if (categoria.Nombre == categoriaNombre)
                    {
                        cboCategoria.SelectedItem = categoria;
                        break;
                    }
                }

                // Guardar el ID de la tarea en el `Tag` para la edición
                txtName.Tag = filaSeleccionada.Cells["ID"].Value.ToString();

                MessageBox.Show("Modo edición activado. Ahora puedes actualizar la tarea.");
            }

            // Si se presiona el botón "Borrar"
            if (e.ColumnIndex == dgTaskApp.Columns["btnBorrar"].Index)
            {
                int tareaId = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
                string query = "DELETE FROM Tareas WHERE ID = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", tareaId);
                            cmd.ExecuteNonQuery();
                        }

                        dgTaskApp.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Tarea eliminada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar tarea: " + ex.Message);
                    }
                }
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            frmCategories CategoriesForm = new frmCategories(usuario, contraseña);
            CategoriesForm.Show();
            this.Hide();
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string queryCategorias = "SELECT ID, nombre FROM Categorias";
            string queryEstados = "SELECT ID, nombreEstado FROM Estados";
            string queryTareas = "SELECT T.ID, T.titulo, T.descripcion, E.nombreEstado, C.nombre FROM Tareas T JOIN Estados E ON T.estadoId = E.ID JOIN Categorias C ON T.categoriaId = C.ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Cargar Categorías
                    SqlCommand cmdCategorias = new SqlCommand(queryCategorias, conn);
                    SqlDataReader readerCategorias = cmdCategorias.ExecuteReader();
                    while (readerCategorias.Read())
                    {
                        Categoria categoria = new Categoria
                        {
                            ID = (int)readerCategorias["ID"],
                            Nombre = readerCategorias["nombre"].ToString()
                        };
                        cboCategoria.Items.Add(categoria);
                    }
                    readerCategorias.Close();

                    // Cargar Estados
                    SqlCommand cmdEstados = new SqlCommand(queryEstados, conn);
                    SqlDataReader readerEstados = cmdEstados.ExecuteReader();
                    while (readerEstados.Read())
                    {
                        Estado estado = new Estado
                        {
                            ID = (int)readerEstados["ID"],
                            Nombre = readerEstados["nombreEstado"].ToString()
                        };
                        cboEstado.Items.Add(estado);
                    }
                    readerEstados.Close();

                    // Cargar Tareas existentes
                    SqlCommand cmdTareas = new SqlCommand(queryTareas, conn);
                    SqlDataReader readerTareas = cmdTareas.ExecuteReader();
                    while (readerTareas.Read())
                    {
                        dgTaskApp.Rows.Add(readerTareas["ID"].ToString(), readerTareas["titulo"].ToString(), readerTareas["descripcion"].ToString(),
                        readerTareas["nombreEstado"].ToString(), readerTareas["nombre"].ToString(), "Editar", "Borrar");

                    }
                    readerTareas.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías, estados o tareas: " + ex.Message);
                }
            }

            if (usuario == "admin" && contraseña == "123")
            {
                btnCategories.Show();
            }
            else
            {
                btnCategories.Hide();
            }
        }


    }
}