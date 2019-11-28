<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalleProcedimiento.aspx.cs" Inherits="prj_Alissez_Estetica.DetalleProcedimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <h3>
              Mantenimiento Detalle de Procedimiento<br />
              <small class="text-muted">Registrar, Actualizar, Eliminar y Consultar</small>
            </h3>
            <br />
            <asp:HiddenField ID="hdfIdDetalleProcedimiento" runat="server" />
            <div class="form-group row col-sm-10">
                <div class="col-sm-5">
                    <asp:Label ID="lblProcedimiento" runat="server" Text="Procedimiento"></asp:Label>
                    <asp:DropDownList ID="ddlProcedimiento" CssClass="form-control" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                    <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row col-sm-10">   
                <div class="col-sm-4">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha del Procedimiento"></asp:Label>
                    <asp:TextBox ID="txtFecha" runat="server"  CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="La Fecha del Procedimiento es Requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad Producto"></asp:Label>
                    <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="La Cantidad es requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="validarCantidad" runat="server" ErrorMessage="Cantidad no disponible" OnServerValidate="validarCantidad_ServerValidate" ControlToValidate="txtCantidad" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:CustomValidator>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblValorCobrado" runat="server" Text="Valor Cobrado"></asp:Label>
                    <asp:TextBox ID="txtValorCobrado" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValorCobrado" runat="server" ControlToValidate="txtValorCobrado" ErrorMessage="El Valor es requerido" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    
                </div>
            </div>
            <div class="form-group row col-sm-8">
                <div class="d-flex justify-content-between mt-3 col-sm-2">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn-primary btn" Text="Registrar" OnClick="btnRegistrar_Click" />
                </div>
                <div class="d-flex justify-content-between mt-3 col-sm-3">
                    <asp:Button ID="btnActualizar" runat="server" CssClass="btn-primary btn" Text="Actualizar" OnClick="btnActualizar_Click" />
                </div>
            </div>
        </div>

        <br />
        <br />

        <asp:GridView ID="gvDetalleProcedimientos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="gvDetalleProcedimiento_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id Detalle P." />
                <asp:BoundField DataField="Procedimiento.nombre" HeaderText="Procedimiento" />
                <asp:BoundField DataField="Producto.nombre" HeaderText="Producto" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="cantidad" HeaderText="Catntidad">
                    <HeaderStyle Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="valor_cobrado" HeaderText="Valor Cobrado">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ButtonField CommandName="SEL" Text="Seleccionar" />
                <asp:ButtonField CommandName="ELIM" Text="Eliminar" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <br />
        <br />
    </form>
</asp:Content>
