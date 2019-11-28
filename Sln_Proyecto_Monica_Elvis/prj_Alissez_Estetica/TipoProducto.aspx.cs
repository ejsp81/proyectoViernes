using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class TipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTipo_Productos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTipoProducto();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            cargarTipo_Productos();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CrearTipo_Producto();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            cargarTipo_Productos();
        }

        protected void gvTipoProducto_RowCommand(object sender, GridViewCommandEventArgs e)
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
            cargarTipo_Productos();
        }

        public void cargarTipo_Productos()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                gvTipoProductos.DataSource = contexto.Tipo_Producto.ToList<Tipo_Producto>();
                gvTipoProductos.DataBind();
            }
        }

       

        private void CrearTipo_Producto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Tipo_Producto rec = new Tipo_Producto();
                rec.nombre = txtNombre.Text;
                contexto.Tipo_Producto.Add(rec);
                contexto.SaveChanges();
            }
        }

        private void SeleccionarFila(int nrofila)
        {
            int Id = int.Parse(gvTipoProductos.Rows[nrofila].Cells[0].Text);

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Tipo_Producto.Where(s => s.id == Id).SingleOrDefault<Tipo_Producto>();
                txtNombre.Text = record.nombre;
                hdfIdTipoProducto.Value = record.id.ToString();
            }
        }
        private void ActualizarTipoProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(hdfIdTipoProducto.Value);
                Tipo_Producto rec = contexto.Tipo_Producto.FirstOrDefault<Tipo_Producto>(s => s.id == Id);
                rec.nombre = txtNombre.Text;
                contexto.SaveChanges();
            }
        }

        private void LimpiarRegistros()
        {
            txtNombre.Text = string.Empty;
        }
       

        private void EliminarFila(int nrofila)
        {
            

            try
            {
                int Id = int.Parse(gvTipoProductos.Rows[nrofila].Cells[0].Text);
                using (BDAlissezEntities contexto = new BDAlissezEntities())
                {
                    Tipo_Producto rec = contexto.Tipo_Producto.FirstOrDefault<Tipo_Producto>(s => s.id == Id);
                    contexto.Tipo_Producto.Remove(rec);
                    contexto.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Eliminar producto", "alert('No se puede eliminar el tipo producto, ya esta siendo usado')", true);
            }

        }
      
    }
}