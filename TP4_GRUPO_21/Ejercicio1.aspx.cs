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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
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

            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open(); 

            string consultaLoc = "SELECT * FROM Localidades WHERE IdProvincia = " + idProvincia;
            SqlCommand sqlCommand = new SqlCommand(consultaLoc, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidad.DataSource = sqlDataReader;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

            sqlDataReader.Close(); 

            string consultaProv = "SELECT * FROM Provincias WHERE IdProvincia != " + idProvincia;
            sqlCommand = new SqlCommand(consultaProv, connection);

            SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();

            ddlProvinciaFinal.DataSource = sqlDataReader2;
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

            ddlLocalidadFinal.Items.Clear();

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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblViaje.ForeColor = Color.Green;
            lblViaje.Text = "Viaje confirmado: " + ddlProvincia.SelectedItem.Text + ", " + ddlLocalidad.SelectedItem.Text + " a " + ddlProvinciaFinal.SelectedItem.Text + ", " + ddlLocalidadFinal.SelectedItem.Text;
            lblViaje.Visible = true;
        }
    }
}