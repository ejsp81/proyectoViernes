using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class WFLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngesar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void validarUsuarioPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string correo = txtUsuario.Text;
            string password = txtPassword.Text;

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Usuarios.Where(s => s.correo == correo && s.contrasenia == password).SingleOrDefault<Usuario>();
                if (record == null)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                    Session.Add("usuario", record);
                }
            }
        }
    }
}