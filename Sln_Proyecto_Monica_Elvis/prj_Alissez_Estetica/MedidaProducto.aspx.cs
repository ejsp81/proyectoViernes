using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class MedidaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMedidaProducto();
        }

       
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCiuad();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            cargarMedidaProducto();
        }
       
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            crearMedidaProducto();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            cargarMedidaProducto();
        }

        protected void gvMedidaProducto_RowCommand(object sender, GridViewCommandEventArgs e)
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
            cargarMedidaProducto();
        }

        public void cargarMedidaProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                gvMedidaProducto.DataSource = contexto.Medida_Producto.ToList<Medida_Producto>();
                gvMedidaProducto.DataBind();
            }
        }



        private void crearMedidaProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Medida_Producto rec = new Medida_Producto();
                rec.nombre = txtNombre.Text;
                rec.detalle = txtDetalle.Text;
                contexto.Medida_Producto.Add(rec);
                contexto.SaveChanges();
            }
        }

        private void SeleccionarFila(int nrofila)
        {
            int Id = int.Parse(gvMedidaProducto.Rows[nrofila].Cells[0].Text);

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Medida_Producto.Where(s => s.id == Id).SingleOrDefault<Medida_Producto>();
                txtNombre.Text = record.nombre;
                txtDetalle.Text = record.detalle;
                hdfIdMedidaProducto.Value = record.id.ToString();
            }
        }
        private void ActualizarCiuad()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(hdfIdMedidaProducto.Value);
                Medida_Producto rec = contexto.Medida_Producto.FirstOrDefault<Medida_Producto>(s => s.id == Id);
                rec.nombre = txtNombre.Text;
                rec.detalle = txtDetalle.Text;
                contexto.SaveChanges();
            }
        }

        private void LimpiarRegistros()
        {
            txtNombre.Text = string.Empty;
            txtDetalle.Text = string.Empty;
        }


        private void EliminarFila(int nrofila)
        {
            int Id = int.Parse(gvMedidaProducto.Rows[nrofila].Cells[0].Text);
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Medida_Producto rec = contexto.Medida_Producto.FirstOrDefault<Medida_Producto>(s => s.id == Id);
                contexto.Medida_Producto.Remove(rec);
                contexto.SaveChanges();
            }
        }
    }
}