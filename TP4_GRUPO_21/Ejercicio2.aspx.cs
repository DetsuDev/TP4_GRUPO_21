using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_GRUPO_21
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        private string consultaSQL = "SELECT * FROM Productos";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();


                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gvProductos.DataSource = sqlDataReader;
                gvProductos.DataBind();

                connection.Close();
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProducto.Text))
            {
                string operador = ddlFiltroIdProducto.SelectedValue;
                string valor = txtIdProducto.Text;

                string consultaFiltrada = "SELECT * FROM Productos WHERE IdProducto " + operador + " " + valor;

                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaFiltrada, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gvProductos.DataSource = sqlDataReader;
                gvProductos.DataBind();

                connection.Close();
            }
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtIdProducto.Text = "";
            ddlFiltroIdProducto.SelectedIndex = 0;

            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            gvProductos.DataSource = sqlDataReader;
            gvProductos.DataBind();

            connection.Close();
        }
    }
}