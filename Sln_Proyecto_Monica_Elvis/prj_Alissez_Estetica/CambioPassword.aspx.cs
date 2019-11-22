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
                validaPassActual.ErrorMessage = "Contraseña Cambiada Satisfactoriamente";
            }
            else
            {
                validaPassActual.ErrorMessage = "La Contraseña Actual es Incorrecta";
            }

        }

        protected void validaPassActual_ServerValidate(object source, ServerValidateEventArgs args)
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
                using (BDAlissezEntities contexto = new BDAlissezEntities())
                {
                    Usuario rec = contexto.Usuarios.FirstOrDefault<Usuario>(s => s.id == us.id);
                    rec.contrasenia = txtNueva.Text;
                    contexto.SaveChanges();
                }
            }
        }
    }
}