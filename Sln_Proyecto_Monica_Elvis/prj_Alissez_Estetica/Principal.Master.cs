﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us =( Usuario) Session["usuario"];
            if (us != null)
            {
                lblLogin.Text = "Bienvenido: " + us.nombre;
            }
            else
            {
                Response.Redirect("WFLogin.aspx");
            }
            
        }      

       
            
    }

}