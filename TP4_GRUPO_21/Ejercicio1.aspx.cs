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
                ddlProvincia.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
                ddlProvinciaFinal.Items.Insert(0, new ListItem("-- Primero elegí destino inicio --", "0"));
                connection.Close();
            }
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProvincia = ddlProvincia.SelectedValue;

            string consultaLoc = "SELECT * FROM Localidades WHERE IdProvincia = " + idProvincia;

            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaLoc, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidad.DataSource = sqlDataReader;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            connection.Close();


            consultaLoc = "SELECT * FROM Provincias WHERE IdProvincia != " + idProvincia;
            sqlCommand = new SqlCommand(consultaLoc, connection);
            connection.Open();

            SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();


            ddlProvinciaFinal.DataSource = sqlDataReader2;
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

            connection.Close();
        }
        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProvincia = ddlProvinciaFinal.SelectedValue;

            string consultaLoc = "SELECT * FROM Localidades WHERE IdProvincia = " + idProvincia;

            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaLoc, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidadFinal.DataSource = sqlDataReader;
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataValueField = "IdLocalidad";
            ddlLocalidadFinal.DataBind();
            ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            connection.Close();
        }
    }
}