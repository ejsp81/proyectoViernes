using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class Producto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProducto();
            cargarTipoProducto();
            cargarMedidaProducto();
            //EntityModelCodeGenerator
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPrducto();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            cargarProducto();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CrearProducto();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            cargarProducto();
        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
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
            cargarProducto();
        }

        public void cargarProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                gvProductos.DataSource = contexto.Productoes.ToList<Producto>();
                gvProductos.DataBind();
            }
        }

        public void cargarTipoProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                ddlTipoProducto.DataSource = contexto.Tipo_Producto.ToList<Tipo_Producto>();
                ddlTipoProducto.DataBind();
            }
        }

        public void cargarMedidaProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                ddlMedidaProducto.DataSource = contexto.Medida_Producto.ToList<Medida_Producto>();
                ddlMedidaProducto.DataBind();
            }
        }

        private void CrearProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Producto rec = new Producto();
                rec.id_tipo_producto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                rec.id_medida_producto = Convert.ToInt32(ddlMedidaProducto.SelectedValue);
                rec.nombre = txtNombre.Text;
                rec.precio_compra = Convert.ToInt32(txtPrecio.Text);
                rec.cantidad_producto = Convert.ToInt32(txtCantidad.Text);
                rec.cantidad_disponible = Convert.ToInt32(txtDisponible.Text);
                contexto.Productoes.Add(rec);
                contexto.SaveChanges();
            }
        }

        private void SeleccionarFila(int nrofila)
        {
            int Id = int.Parse(gvProductos.Rows[nrofila].Cells[0].Text);

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Productoes.Where(s => s.id == Id).SingleOrDefault<Producto>();
                ddlTipoProducto.SelectedValue = record.id_medida_producto.ToString();
                ddlMedidaProducto.SelectedValue = record.id_medida_producto.ToString();
                txtNombre.Text = record.nombre;
                txtPrecio.Text = record.precio_compra.ToString();
                txtCantidad.Text = record.cantidad_producto.ToString();
                txtDisponible.Text = record.cantidad_disponible.ToString();
                hdfIdProducto.Value = record.id.ToString();
            }
        }
        private void ActualizarPrducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(hdfIdProducto.Value);
                Producto rec = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                rec.id_tipo_producto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                rec.id_medida_producto = Convert.ToInt32(ddlMedidaProducto.SelectedValue);
                rec.nombre = txtNombre.Text;
                rec.precio_compra = Convert.ToInt32(txtPrecio.Text);
                rec.cantidad_producto = Convert.ToInt32(txtCantidad.Text);
                rec.cantidad_disponible = Convert.ToInt32(txtDisponible.Text);
                contexto.SaveChanges();
            }
        }

        private void LimpiarRegistros()
        {
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDisponible.Text = string.Empty;
        }


        private void EliminarFila(int nrofila)
        {
            int Id = int.Parse(gvProductos.Rows[nrofila].Cells[0].Text);
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Producto rec = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                contexto.Productoes.Remove(rec);
                contexto.SaveChanges();
            }
        }

        
    }
}