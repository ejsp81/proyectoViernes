<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MedidaProducto.aspx.cs" Inherits="prj_Alissez_Estetica.MedidaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre de la Medida"></asp:Label>
                <asp:HiddenField ID="hdfIdMedidaProducto" runat="server" />
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Digite El Nombre de la Medida" CssClass="form-control col-sm-6"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDetalle" runat="server" Text="Detalle de la Medida"></asp:Label>
                <asp:TextBox ID="txtDetalle" runat="server" placeholder="Digite El Detalle de la Medida" CssClass="form-control col-sm-6"></asp:TextBox>
            </div>
            <div class="row">
                <div class="d-flex justify-content-between mt-3 col-sm-2">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn-primary btn" Text="Registrar" OnClick="btnRegistrar_Click" />
                </div>
                <div class="d-flex justify-content-between mt-3 col-sm-3">
                    <asp:Button ID="btnActualizar" runat="server" CssClass="btn-primary btn" Text="Actualizar" OnClick="btnActualizar_Click" />
                </div>
            </div>
        </div>

        <br />
        <asp:GridView ID="gvMedidaProducto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="gvMedidaProducto_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id Medida" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre de Medida" />
                <asp:BoundField DataField="detalle" HeaderText="Detalle de Medida" />
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
    </form>
    <br />

</asp:Content>
