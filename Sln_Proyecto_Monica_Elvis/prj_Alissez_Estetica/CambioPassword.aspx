<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="prj_Alissez_Estetica.CambioPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <h3>Cambiar Contraseña<br /></h3>
            <br />
            <div class="form-group">
                <asp:Label ID="lblActual" runat="server" Text="Contraseña Actual"></asp:Label>
                <asp:TextBox ID="txtActual" runat="server" placeholder="Digite La Contraseña Actual" CssClass="form-control col-sm-6" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqActual" runat="server" ControlToValidate="txtActual" ErrorMessage="La Contraseña Actual es Requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="validaPassActual" runat="server" ControlToValidate="txtActual" ErrorMessage="La contraseña Actual No es Correcta" OnServerValidate="validaPassActual_ServerValidate"></asp:CustomValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNueva" runat="server" Text="Nueva Contraseña"></asp:Label>
                <asp:TextBox ID="txtNueva" runat="server" placeholder="Digite La Nueva Contraseña" CssClass="form-control col-sm-6" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNueva" runat="server" ControlToValidate="txtNueva" ErrorMessage="La Nueva Contraseña Es Requerida" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblConfirma" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox ID="txtConfirma" runat="server" placeholder="Confirme la Contraseña" CssClass="form-control col-sm-6" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqConfirma" runat="server" ControlToValidate="txtConfirma" ErrorMessage="Debe Confirmar La Contraseña" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </div>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La Contraseña Nueva no coincide con la de confirmar" ForeColor="#CC3300" ControlToCompare="txtConfirma" ControlToValidate="txtNueva"></asp:CompareValidator>
            <div class="row">
                <div class="d-flex justify-content-between mt-3 col-sm-2">                    
                    <asp:Button ID="btnGrabar" runat="server" CssClass="btn-primary btn" Text="Cambiar" OnClick="btnGrabar_Click"  />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
