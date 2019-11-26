<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="prj_Alissez_Estetica.Producto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <h3>
              Mantenimiento de Producto<br />
              <small class="text-muted">Registrar, Actualizar, Eliminar y Consultar</small>
            </h3>
            <br />
            <asp:HiddenField ID="hdfIdProducto" runat="server" />
            <div class="form-group row col-sm-12">
                <div class="col-sm-4">
                    <asp:Label ID="lblTipoProducto" runat="server" Text="Tipo del Producto"></asp:Label>
                    <asp:DropDownList ID="ddlTipoProducto" CssClass="form-control" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblMedidaProducto" runat="server" Text="Medida del Producto"></asp:Label>
                    <asp:DropDownList ID="ddlMedidaProducto" CssClass="form-control" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                </div>
                 <div class="col-sm-4">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre del Producto"></asp:Label>
                    <asp:TextBox ID="txtNombre" placeholder="Digite el Nombre del Producto" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El Nombre del Producto es requerido" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row col-sm-12">
                <div class="col-sm-4">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio Producto"></asp:Label>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="El Precio del Producto es requerido" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad Producto"></asp:Label>
                    <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="La Cantidad del Prodcuto es requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblDisponible" runat="server" Text="Cantidad Disponible"></asp:Label>
                    <asp:TextBox ID="txtDisponible" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDisponible" runat="server" ControlToValidate="txtDisponible" ErrorMessage="La Cantidad Disponible es requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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

        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="gvProducto_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id Producto" />
                <asp:BoundField DataField="Tipo_Producto.nombre" HeaderText="Tipo Producto" />
                <asp:BoundField DataField="Medida_Producto.nombre" HeaderText="Medida Producto" />
                <asp:BoundField DataField="nombre" HeaderText="Descripcion" />
                <asp:BoundField DataField="precio_compra" HeaderText="Precio">
                    <HeaderStyle Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cantidad_producto" HeaderText="Cantidad Producto">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cantidad_disponible" HeaderText="Cantidad Disponible">
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
