<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_GRUPO_21.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Id Producto: 
            <asp:DropDownList ID="ddlFiltroIdProducto" runat="server">
                <asp:ListItem Value="=">Igual a:</asp:ListItem>
                <asp:ListItem Value=">">Mayor a:</asp:ListItem>
                <asp:ListItem Value="<">Menor a:</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtIdProducto" runat="server"></asp:TextBox>
            <br/><br/>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnQuitarFiltro" runat="server" Text="Quitar filtro" OnClick="btnQuitarFiltro_Click" />
            <br/><br/>
            <asp:GridView ID="gvProductos" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
