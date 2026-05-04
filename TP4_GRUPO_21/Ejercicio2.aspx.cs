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
            string consultaFiltrada = "SELECT * FROM Productos WHERE 1=1";
            bool filtroIdProducto = false;
            bool filtroIdCategoria = false;

            if (!string.IsNullOrEmpty(txtIdProducto.Text))
            {
                string operador = ddlFiltroIdProducto.SelectedValue;
                consultaFiltrada += " AND IdProducto " + operador + " " + txtIdProducto.Text;
                filtroIdProducto = true;

            }

            if (!string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                string operador = ddlFiltroIdCategoria.SelectedValue;
                consultaFiltrada += " AND IdCategoría " + operador + " " + txtIdCategoria.Text;
                filtroIdCategoria = true;

            }

            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaFiltrada, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            gvProductos.DataSource = sqlDataReader;
            gvProductos.DataBind();

            connection.Close();

            if (filtroIdProducto)
            {
                gvProductos.HeaderRow.Cells[0].BackColor = System.Drawing.Color.LightGreen;
                foreach (GridViewRow row in gvProductos.Rows)
                {
                    row.Cells[0].BackColor = System.Drawing.Color.LightGreen;
                }
            }

            if (filtroIdCategoria)
            {
                gvProductos.HeaderRow.Cells[3].BackColor = System.Drawing.Color.LightBlue;
                foreach (GridViewRow row in gvProductos.Rows)
                {

                    row.Cells[3].BackColor = System.Drawing.Color.LightBlue;
                }
            }



            txtIdProducto.Text = "";
            txtIdCategoria.Text = "";
        }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtIdProducto.Text = "";
            ddlFiltroIdProducto.SelectedIndex = 0;
            txtIdCategoria.Text = "";
            ddlFiltroIdCategoria.SelectedIndex = 0;

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