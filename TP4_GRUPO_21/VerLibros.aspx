<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerLibros.aspx.cs" Inherits="TP4_GRUPO_21.VerLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Listado de libros:</h3>
            <asp:GridView ID="gvLibros" runat="server">
            </asp:GridView>
            <br />
            <asp:LinkButton ID="lbtnConsultarOtroTema" runat="server" OnClick="lbtnConsultarOtroTema_Click">Consultar otro tema</asp:LinkButton>
        </div>
    </form>
</body>
</html>