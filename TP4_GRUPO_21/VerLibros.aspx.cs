using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_GRUPO_21
{
    public partial class VerLibros : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTema = Request.QueryString["id"];
                string precio = Request.QueryString["precio"];

                string consultaSQL = "SELECT * FROM Libros WHERE IdTema = " + idTema;
                if (precio != "Todos")
                {
                    if (precio == "< 60.0000")
                    {
                        consultaSQL += " AND Precio < 60.0000";
                    }
                    else if (precio == "> 60.0000")
                    {
                        consultaSQL += " AND Precio > 60.0000";
                    }
                }
                else {
                    consultaSQL += " AND Precio > 0";
                }

                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gvLibros.DataSource = sqlDataReader;
                gvLibros.DataBind();

                decimal total = 0;
                foreach (GridViewRow fila in gvLibros.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells[3].Text);
                }

                lblResultados.Text = "Se encontraron " + gvLibros.Rows.Count + " libros.";
                lblPrecioTotal.Text = "El precio total de los libros es: $" + total.ToString(); 


                connection.Close();
            }
        }

        protected void lbtnConsultarOtroTema_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}