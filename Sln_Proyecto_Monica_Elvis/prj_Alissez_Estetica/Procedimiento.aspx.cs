using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class Procedimiento1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProcedimiento();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            crearProcedimiento();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            cargarProcedimiento();

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarProcedimiento();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            cargarProcedimiento();
        }

        protected void gvProcedimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //obtener la fila que se esta tratando de obtener
            int nrofila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "SEL")
            {
                SeleccionarFila(nrofila);
                btnActualizar.Enabled = true;
                btnRegistrar.Enabled = false;
            }

            if (e.CommandName == "ELIM")
            {
                EliminarFila(nrofila);
                LimpiarRegistros();
                btnActualizar.Enabled = false;
                btnRegistrar.Enabled = true;
            }
            cargarProcedimiento();
        }

        public void cargarProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                gvProcedimiento.DataSource = contexto.Procedimientoes.ToList<Procedimiento>();
                gvProcedimiento.DataBind();
            }
        }



        private void crearProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Procedimiento rec = new Procedimiento();
                rec.nombre = txtNombre.Text;
                string fecha= txtFecha.Text;
                rec.fecha = DateTime.Parse(fecha);
                contexto.Procedimientoes.Add(rec);
                contexto.SaveChanges();
            }
        }

        
        private void SeleccionarFila(int nrofila)
        {
            int Id = int.Parse(gvProcedimiento.Rows[nrofila].Cells[0].Text);

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Procedimientoes.Where(s => s.id == Id).SingleOrDefault<Procedimiento>();
                txtNombre.Text = record.nombre;
                DateTime fecha = Convert.ToDateTime(record.fecha);
                txtFecha.Text =  fecha.ToShortDateString();
                //lblFecha.Text= fecha.ToShortDateString();
                hdfIdProcedimiento.Value = record.id.ToString();
            }
        }
        private void ActualizarProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(hdfIdProcedimiento.Value);
                Procedimiento rec = contexto.Procedimientoes.FirstOrDefault<Procedimiento>(s => s.id == Id);
                rec.nombre = txtNombre.Text;
                string fecha = txtFecha.Text;
                rec.fecha = DateTime.Parse(fecha);
                contexto.SaveChanges();
            }
        }

        private void LimpiarRegistros()
        {
            txtNombre.Text = string.Empty;
            txtFecha.Text = string.Empty;
        }


        private void EliminarFila(int nrofila)
        {
            int Id = int.Parse(gvProcedimiento.Rows[nrofila].Cells[0].Text);
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Procedimiento rec = contexto.Procedimientoes.FirstOrDefault<Procedimiento>(s => s.id == Id);
                contexto.Procedimientoes.Remove(rec);
                contexto.SaveChanges();
            }

        }
    }
}