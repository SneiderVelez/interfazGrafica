DOCUMENTACION

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace interfazGrafica
{
/// <summary>
/// Clase FrmLogin que representa el formulario de inicio de sesión.
/// </summary>
public partial class FrmLogin : Form
{
/// <summary>
/// Constructor de la clase FrmLogin.
/// Inicializa los componentes del formulario.
/// </summary>
public FrmLogin()
{
InitializeComponent();
}

        /// <summary>
        /// Maneja el evento de clic en el botón de inicio de sesión.
        /// Valida las credenciales ingresadas y muestra la siguiente ventana si son correctas.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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

        /// <summary>
        /// Valida las credenciales ingresadas comparándolas con la base de datos.
        /// </summary>
        /// <param name="usuario">Nombre de usuario ingresado.</param>
        /// <param name="contrasena">Contraseña ingresada.</param>
        /// <returns>True si las credenciales son correctas, False en caso contrario.</returns>
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

        /// <summary>
        /// Muestra un mensaje de error en un cuadro de diálogo.
        /// </summary>
        /// <param name="mensaje">Mensaje de error a mostrar.</param>
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }

}

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace interfazGrafica
{
/// <summary>
/// Formulario principal para la gestión de tareas.
/// Permite agregar, editar y eliminar tareas, además de gestionar categorías y estados.
/// </summary>
public partial class frmList : Form
{
public string usuario;
public string contraseña;

        /// <summary>
        /// Constructor de la clase frmList.
        /// </summary>
        /// <param name="usuarioRecibido">Nombre de usuario autenticado.</param>
        /// <param name="contraseñaRecibida">Contraseña del usuario autenticado.</param>
        public frmList(string usuarioRecibido, string contraseñaRecibida)
        {
            InitializeComponent();
            usuario = usuarioRecibido;
            contraseña = contraseñaRecibida;
        }

        /// <summary>
        /// Representa el estado de una tarea.
        /// </summary>
        public class Estado
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        /// <summary>
        /// Representa la categoría de una tarea.
        /// </summary>
        public class Categoria
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        /// <summary>
        /// Valida que los campos obligatorios estén completos.
        /// </summary>
        /// <returns>True si los campos son válidos, false en caso contrario.</returns>
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

        /// <summary>
        /// Maneja el evento de clic en el botón Agregar, permitiendo insertar o actualizar tareas.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query;

            // Si se está editando, actualiza la tarea
            if (txtName.Tag != null)
            {
                if (!int.TryParse(txtName.Tag.ToString(), out int tareaId))
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar tarea: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene el ID del usuario autenticado.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <returns>ID del usuario si existe, -1 en caso contrario.</returns>
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

        /// <summary>
        /// Maneja el evento de carga del formulario y llena los controles con información de la base de datos.
        /// </summary>
        private void frmList_Load(object sender, EventArgs e)
        {
            // Implementación de la carga de datos en los controles.
        }
    }

}

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace interfazGrafica
{
/// <summary>
/// Representa el formulario de gestión de categorías en la interfaz gráfica.
/// Permite cargar, agregar y eliminar categorías desde una base de datos.
/// </summary>
public partial class frmCategories : Form
{
private string usuarioIngresado;
private string contrasenaIngresada;

        /// <summary>
        /// Constructor de la clase frmCategories.
        /// </summary>
        /// <param name="usuario">Nombre de usuario autenticado.</param>
        /// <param name="contrasena">Contraseña del usuario autenticado.</param>
        public frmCategories(string usuarioRecibido, string contrasenaRecibida)
        {
            InitializeComponent();
            usuarioIngresado = usuarioRecibido;
            contrasenaIngresada = contrasenaRecibida;
            CargarCategorias();
        }

        /// <summary>
        /// Carga las categorías desde la base de datos y las muestra en el DataGridView.
        /// </summary>
        private void CargarCategorias()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
            string query = "SELECT ID, nombre, descripcion, fechaCreacion FROM Categorias";

            dgCategories.Rows.Clear();

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
                            int index = dgCategories.Rows.Add();
                            dgCategories.Rows[index].Cells[0].Value = reader["ID"];
                            dgCategories.Rows[index].Cells[1].Value = reader["nombre"];
                            dgCategories.Rows[index].Cells[2].Value = reader["descripcion"];
                            dgCategories.Rows[index].Cells[3].Value = reader["fechaCreacion"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las categorías: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Valida que los campos obligatorios estén completos antes de agregar una categoría.
        /// </summary>
        /// <returns>True si los campos son válidos, de lo contrario, false.</returns>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCategories.Text))
            {
                MessageBox.Show("El campo 'Categorías' es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Agregar, permitiendo insertar nuevas categorías en la base de datos.
        /// </summary>
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
                    MessageBox.Show($"Error al agregar la categoría: {ex.Message}");
                }
            }
        }
    }

}

# Manual Técnico de la Aplicación de Gestión de Tareas

Descripción General del Sistema
La aplicación permite a los usuarios gestionar sus tareas de manera sencilla y eficiente. Algunas de sus principales características incluyen:
Manejo de usuarios: Registro e inicio de sesión. Creación, edición y eliminación de tareas. Organización de tareas en categorías. Uso de una base de datos SQL Server para almacenar la información. Conexión con la base de datos mediante ADO.NET.
El sistema sigue una arquitectura en capas con las siguientes partes:
Interfaz gráfica (Windows Forms): Permite la interacción del usuario con la aplicación. Lógica de negocio: Procesa las reglas del negocio y gestiona los datos.
Base de datos (SQL Server): Almacena información de usuarios, categorías y tareas.

---

Diagrama de Arquitectura
Aquí puedes insertar un diagrama de arquitectura mostrando la interacción entre las capas.

---

Estructura de la Base de Datos
La base de datos TareasDB contiene tres tablas principales:
Tabla: Usuarios
Campo Tipo de Dato Descripción
ID INT IDENTITY(1,1) PRIMARY KEY Identificador único del usuario
nombre VARCHAR(100) NOT NULL Nombre de usuario
contrasena VARCHAR(255) NOT NULL Contraseña almacenada de forma segura
Tabla: Categorias
Campo Tipo de Dato Descripción
ID INT IDENTITY(1,1) PRIMARY KEY Identificador único de la categoría
nombre VARCHAR(100) NOT NULL Nombre de la categoría
descripcion VARCHAR(255) Descripción de la categoría
fechaCreacion DATETIME DEFAULT GETDATE() Fecha en que se creó la categoría
Tabla: Tareas
Campo Tipo de Dato Descripción
ID INT IDENTITY(1,1) PRIMARY KEY Identificador único de la tarea
nombre VARCHAR(100) NOT NULL Nombre de la tarea
descripcion TEXT Descripción de la tarea
fechaCreacion DATETIME NOT NULL Fecha de creación de la tarea
idCategoria INT Relación con la tabla Categorias
estado VARCHAR(50) NOT NULL DEFAULT 'Pendiente' Estado de la tarea (Pendiente, En Proceso, Completa)
Descripción de los Módulos
Módulo de Autenticación
Este módulo se encarga de la seguridad de la aplicación. Incluye:
● Inicio de sesión con usuario y contraseña.
● Validación de credenciales en la base de datos.
● Redirección a la pantalla principal tras un inicio de sesión exitoso.
Módulo de Gestión de Tareas
● Permite agregar nuevas tareas, especificando nombre, descripción y fecha de vencimiento.
● Editar y eliminar tareas existentes.
● Cambiar el estado de las tareas entre Pendiente, En proceso y Completada.
● Asignar cada tarea a una categoría específica.
Módulo de Categorías
● Permite crear nuevas categorías para organizar las tareas.
● Listar, editar y eliminar categorías.
● Asociar tareas a categorías para una mejor gestión.
Conexión a la Base de Datos con ADO.NET
La aplicación utiliza ADO.NET para la conexión con la base de datos SQL Server. Se emplea SqlConnection, SqlCommand y SqlDataReader para la interacción con la base de datos. Aquí un ejemplo básico de conexión:
string connectionString = ConfigurationManager.ConnectionStrings["TareasDB"].ConnectionString;
using (SqlConnection conn = new SqlConnection(connectionString))
{
conn.Open();
string query = "SELECT \* FROM Categorias";
using (SqlCommand cmd = new SqlCommand(query, conn))
{
using (SqlDataReader reader = cmd.ExecuteReader())
{
while (reader.Read())
{
// Procesar los datos
}
}
}
}

Este método garantiza que la conexión a la base de datos sea eficiente y se cierre correctamente una vez utilizada.

# Manual de Usuario - Aplicación de Gestión de Tareas

1. Introducción
   Bienvenido al Manual de Usuario de la aplicación de gestión de tareas. Este documento te guiará a través de la instalación, configuración y uso de la aplicación, explicando cada una de sus funciones para que puedas aprovecharla al máximo.

---

2. Instalación y Configuración
   Requisitos del sistema
   Antes de instalar la aplicación, asegúrate de que tu computadora cumple con los siguientes requisitos mínimos:
   ● Sistema operativo: Windows 10 o superior
   ● Procesador: 2.0 GHz o superior
   ● Memoria RAM: 4 GB o superior
   ● Espacio en disco: Mínimo 500 MB de espacio disponible
   ● Base de datos: SQL Server
   ● Requisitos adicionales:
   ○ .NET Framework 4.7 o superior
   ○ Conexión a Internet (opcional, solo si se requiere actualización)

---

Instalación de la Aplicación
Para instalar la aplicación de gestión de tareas, sigue los siguientes pasos:

1. Descarga el archivo instalador GestionTareasSetup.exe desde el enlace proporcionado.
2. Ejecuta el archivo y sigue las instrucciones del asistente de instalación.
3. Asegúrate de tener una conexión estable a Internet durante la instalación.
4. Una vez finalizada la instalación, abre la aplicación desde el acceso directo en el escritorio o desde el menú de inicio.
5. Si es la primera vez que usas la aplicación, deberás crear una cuenta de usuario en el módulo de autenticación.

---

Módulo de Autenticación
Este módulo permite a los usuarios iniciar sesión en la aplicación.
Inicio de sesión

1. Abre la aplicación y dirígete a la pantalla de inicio de sesión.
2. Ingresa tu nombre de usuario y contraseña.
3. Haz clic en el botón Iniciar Sesión.
4. Si los datos son correctos, serás redirigido a la pantalla principal de la aplicación.
5. En caso de error, revisa las credenciales ingresadas e intenta nuevamente.

---

Módulo de Gestión de Categorías
El módulo de categorías te permite organizar las tareas en diferentes grupos.
Agregar una nueva categoría

1. Inicia sesión en la aplicación.
2. Dirígete a la pestaña Categorías.
3. En el campo "Categorías", ingresa el nombre de la nueva categoría.
4. Opcional: Agrega una breve descripción.
5. Selecciona una fecha de creación.
6. Haz clic en Guardar.
7. La nueva categoría se mostrará en la tabla de categorías.
   Editar una categoría
8. Selecciona la categoría que deseas modificar.
9. Cambia la información en los campos de texto.
10. Haz clic en Guardar cambios.
11. La categoría se actualizará en la tabla automáticamente.
    Eliminar una categoría
12. En la tabla de categorías, busca la categoría que deseas eliminar.
13. Haz clic en el botón Eliminar en la fila correspondiente.
14. Confirma la eliminación cuando se te solicite.
15. La categoría se eliminará de la base de datos.

---

Módulo de Gestión de Tareas
Este módulo permite a los usuarios administrar sus tareas dentro de las categorías creadas.
Agregar una nueva tarea

1. Inicia sesión y ve a la pestaña Tareas.
2. Haz clic en el botón Nueva tarea.
3. Introduce el nombre de la tarea en el campo correspondiente.
4. Ingresa una descripción.
5. Selecciona una categoría para la tarea.
6. Elige una fecha de vencimiento.
7. Haz clic en Guardar.
   Modificar una tarea
8. En la lista de tareas, busca la que deseas modificar.
9. Haz doble clic sobre la tarea o selecciona el botón Editar.
10. Modifica los datos que necesites.
11. Guarda los cambios.
    Eliminar una tarea
12. Selecciona la tarea que deseas eliminar.
13. Presiona el botón Eliminar.
14. Confirma la eliminación cuando se te solicite.
15. La tarea se eliminará de la base de datos.

---
