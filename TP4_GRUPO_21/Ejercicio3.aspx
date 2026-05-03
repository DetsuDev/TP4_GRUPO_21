<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4_GRUPO_21.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">Seleccionar Tema:</td>
                    <td>
                        <asp:DropDownList ID="ddlTemas" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Precio:</td>
                    <td>
                        <asp:DropDownList ID="ddlPrecios" runat="server">
                            <asp:ListItem Selected="True" Value="Todos">Todos</asp:ListItem>
                            <asp:ListItem Value="&lt; 60.0000">&lt; 60.0000</asp:ListItem>
                            <asp:ListItem Value="&gt; 60.0000">&gt; 60.0000</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:LinkButton ID="lbtnVerLibros" runat="server" OnClick="lbtnVerLibros_Click">Ver Libros</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
