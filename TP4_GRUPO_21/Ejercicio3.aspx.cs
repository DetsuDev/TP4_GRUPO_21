using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_GRUPO_21
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {

        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        private string consultaSQL = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                ddlTemas.DataSource = sqlDataReader;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();


                connection.Close();
            }
        }
        protected void lbtnVerLibros_Click(object sender, EventArgs e)
        {
            string idTema = ddlTemas.SelectedValue;
            string precio = ddlPrecios.SelectedValue;
            Response.Redirect("VerLibros.aspx?id=" + idTema + "&precio=" + precio);
        }

    }
}