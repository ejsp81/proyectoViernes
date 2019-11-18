using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                lblActual.Text = "Se puede modificar";
            }
            else
            {
                lblActual.Text = "no no no";
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Usuario us = (Usuario)Session["usuario"];
            string pass = us.contrasenia;
            if (pass != txtActual.Text)
            {
                args.IsValid = false;
                //reqActual.ErrorMessage = "La contraseña No coincide";

            }
            else
            {
                args.IsValid = true;
                //lblActual.Text = "Se puede modificar";
            }
        }
    }
}