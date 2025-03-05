using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace interfazGrafica
{
    public partial class frmCategories : Form
    {
        private string usuarioIngresado;
        private string contrasenaIngresada;
        public frmCategories(string usuario, string contrasena)
        {
            InitializeComponent();
            usuarioIngresado = usuario;
            contrasenaIngresada = contrasena;

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgCategories.Rows.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query = "SELECT ID, nombre, descripcion, fechaCreacion FROM Categorias";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgCategories.Rows.Add(reader["ID"], reader["nombre"], reader["descripcion"], reader["fechaCreacion"], "Borrar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías: " + ex.Message);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCategories.Text))
            {
                MessageBox.Show("El campo 'Categorias' es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.");
                return false;
            }

            if (dtpFechaCreacion == null)
            {
                MessageBox.Show("Debes seleccionar una fecha de creacion.");
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query = "INSERT INTO Categorias (nombre, descripcion, fechaCreacion) VALUES (@nombre, @descripcion, @fechaCreacion)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtCategories.Text);
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaCreacion.Value);

                        cmd.ExecuteNonQuery();
                    }

                    CargarCategorias();
                   
                    txtCategories.Clear();
                    txtDescripcion.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar categoría: " + ex.Message);
                }
            }
        }

        private void dgCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgCategories.Columns["btnBorrar"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta categoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;
                    string categoriaNombre = dgCategories.Rows[rowIndex].Cells["nombre"].Value.ToString();

                    string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
                    string query = "DELETE FROM Categorias WHERE nombre = @nombre";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@nombre", categoriaNombre);
                                cmd.ExecuteNonQuery();
                            }

                            CargarCategorias();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar categoría: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmList listaForm = new frmList(usuarioIngresado, contrasenaIngresada);
            listaForm.Show();
            this.Close();
        }
    }
}
