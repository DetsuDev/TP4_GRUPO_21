using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_GRUPO_21
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private string consultaSQL = "SELECT * FROM Provincias";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                ddlProvincia.DataSource = sqlDataReader;
                ddlProvincia.DataTextField = "NombreProvincia";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();


                connection.Close();
            }
        }
    }
}