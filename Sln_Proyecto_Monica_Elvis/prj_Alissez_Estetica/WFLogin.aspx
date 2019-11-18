﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFLogin.aspx.cs" Inherits="prj_Alissez_Estetica.WFLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" href="./Content/bootstrap.min.css" rel="stylesheet" />    
    <script type="text/javascript" src="./Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="./Scripts/jquery-3.0.0.min.js"></script>
    <link type="text/css" href="./css/login.css" rel="stylesheet"/>
    </head>
<body>
    	<div class="container h-100">
            <br />
            <br />
            <br />
		    <div class="d-flex justify-content-center h-100">
			    <div class="user_card">
				    <div class="d-flex justify-content-center">
					    <div class="brand_logo_container ">
						    <img src="./Images/principal.png" class="brand_logo" alt="Logo">
					    </div>
				    </div>
				    <div class="d-flex justify-content-center form_container">
					    <form id="form1" runat="server">
						    <div class="form-group">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Dige su Email" CssClass="form-control input_user" TextMode="Email"></asp:TextBox>							
						    </div>
						    <div class="form-group">
                                <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                                <asp:TextBox ID="txtPassword" placeholder="Dige su Contraseña" runat="server" CssClass="form-control input_pass" TextMode="Password"></asp:TextBox>
						    </div>
                            <asp:CustomValidator ID="validarUsuarioPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="El usuario o Contraseña es Incorrecto" OnServerValidate="validarUsuarioPassword_ServerValidate"></asp:CustomValidator>
						    <div class="d-flex justify-content-center mt-3">
                                <asp:Button ID="btnIngesar" runat="server" CssClass="btn-primary btn" Text="Ingresar" OnClick="btnIngesar_Click"/>				 	        				                
				            </div>
					    </form>
				    </div>		
				   
			    </div>
		    </div>
	    </div>
</body>
</html>