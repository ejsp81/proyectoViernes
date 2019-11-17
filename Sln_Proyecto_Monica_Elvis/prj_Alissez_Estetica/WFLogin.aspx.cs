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
            string correo = txtUsuario.Text;
            string password = txtPassword.Text;

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Usuarios.Where(s => s.correo == correo && s.contrasenia==password).SingleOrDefault<Usuario>();
                if (record == null)
                {
                    txtPassword.Text = "incorrecto";
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
    }
}