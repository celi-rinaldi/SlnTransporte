<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaAuto.aspx.cs" Inherits="WebTransportes.VistaAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Marca: 
            <asp:DropDownList ID="ddlMarcas" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
             Modelo: <asp:TextBox ID="txtModelo" runat="server" ></asp:TextBox>
            <br />
               Matricula: <asp:TextBox ID="txtMatricula" runat="server" ></asp:TextBox>
                
              <br />
            Precio: <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
               Id: <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <br />
            Buscar autos por marca: <asp:DropDownList ID="ddlBuscarPorMarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBuscarPorMarca_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Height="29px" Width="69px" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" Height="28px" Width="55px" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Height="30px" Width="69px" />
            <br />
            <br />
            <asp:GridView ID="gridAutos" runat="server" Width="385px">
            </asp:GridView>
            <br />

        </div>
    </form>
</body>
</html>
