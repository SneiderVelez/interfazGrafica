using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace interfazGrafica
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUser.Text;
            string contrasenaIngresada = txtPassword.Text;

            if (ValidarCredenciales(usuarioIngresado, contrasenaIngresada))
            {
                MessageBox.Show("¡Inicio de sesión exitoso!");

                frmList listaForm = new frmList(usuarioIngresado, contrasenaIngresada);
                listaForm.Show();  
                this.Hide();  
            }
        }

        private bool ValidarCredenciales(string usuario, string contrasena)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query = "SELECT * FROM Usuarios WHERE nombreUsuario = @usuario AND contrasena = @contrasena";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contrasenaDB = reader["contrasena"].ToString();

                                if (contrasena == contrasenaDB)
                                {
                                    return true;
                                }
                                else
                                {
                                    MostrarError("Contraseña incorrecta.");
                                    txtPassword.Clear();
                                    return false;
                                }
                            }
                            else
                            {
                                MostrarError("Usuario no encontrado.");
                                txtUser.Clear();
                                txtPassword.Clear();
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error de conexión: " + ex.Message);
                    return false;
                }
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
