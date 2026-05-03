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

                string consultaSQL = "SELECT * FROM Libros WHERE IdTema = " + idTema;

                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gvLibros.DataSource = sqlDataReader;
                gvLibros.DataBind();

                connection.Close();
            }
        }

        protected void lbtnConsultarOtroTema_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}