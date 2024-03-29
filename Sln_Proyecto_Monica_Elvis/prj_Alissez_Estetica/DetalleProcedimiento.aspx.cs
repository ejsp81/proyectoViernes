﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_Alissez_Estetica
{
    public partial class DetalleProcedimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                cargarProcedimiento();
                cargarProducto();
            }
                
            cargarDetalleProcedimiento();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CrearDetalleProcedimiento();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            cargarDetalleProcedimiento();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDetalleProcedimiento();
            LimpiarRegistros();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            cargarDetalleProcedimiento();
        }

        protected void gvDetalleProcedimiento_RowCommand(object sender, GridViewCommandEventArgs e)
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
            cargarDetalleProcedimiento();
        }

        public void cargarDetalleProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                gvDetalleProcedimientos.DataSource = contexto.Detalle_Procedimiento.ToList<Detalle_Procedimiento>();
                gvDetalleProcedimientos.DataBind();
            }
        }

       

        public void cargarProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                ddlProcedimiento.DataSource = contexto.Procedimientoes.ToList<Procedimiento>();
                ddlProcedimiento.DataBind();
            }
        }

        public void cargarProducto()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                ddlProducto.DataSource = contexto.Productoes.ToList<Producto>();
                ddlProducto.DataBind();
            }
        }

        private void CrearDetalleProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    int Id = Convert.ToInt32(ddlProducto.SelectedValue);
                    Producto pro = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                    int cant = Convert.ToInt32(pro.cantidad_disponible);
                    
                        pro.cantidad_disponible = cant - Convert.ToInt32(txtCantidad.Text);
                        contexto.SaveChanges();
                        Detalle_Procedimiento rec = new Detalle_Procedimiento();
                        rec.id_procedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
                        rec.id_producto = Convert.ToInt32(ddlProducto.SelectedValue);
                        string fecha = txtFecha.Text;
                        rec.fecha = DateTime.Parse(fecha);
                        rec.cantidad = Convert.ToInt32(txtCantidad.Text);
                        rec.valor_cobrado = Convert.ToInt32(txtValorCobrado.Text);
                        contexto.Detalle_Procedimiento.Add(rec);
                        contexto.SaveChanges();
                }

                //ACTUALIZA PRODUCTO
                /**int Id = Convert.ToInt32(ddlProducto.SelectedValue);
                Producto pro = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                int cant = Convert.ToInt32(pro.cantidad_disponible);
                if (cant< Convert.ToInt32(txtCantidad.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cantidad", "alert('la cantidad no esta disponible')", true);
                }
                else
                {
                    pro.cantidad_disponible = cant - Convert.ToInt32(txtCantidad.Text);
                    contexto.SaveChanges();
                    Detalle_Procedimiento rec = new Detalle_Procedimiento();
                    rec.id_procedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
                    rec.id_producto = Convert.ToInt32(ddlProducto.SelectedValue);
                    string fecha = txtFecha.Text;
                    rec.fecha = DateTime.Parse(fecha);
                    rec.cantidad = Convert.ToInt32(txtCantidad.Text);
                    rec.valor_cobrado = Convert.ToInt32(txtValorCobrado.Text);
                    contexto.Detalle_Procedimiento.Add(rec);
                    contexto.SaveChanges();

                }**/
                
                

            }
        }

        private void CargarCantidad()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                //ACTUALIZA PRODUCTO
                int Id = Convert.ToInt32(ddlProducto.SelectedValue);
                Producto pro = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                int cant = Convert.ToInt32(pro.cantidad_disponible);
                lblCantidad.Text = lblCantidad.Text + " ("+cant+")";
               
            }
        }

        private void SeleccionarFila(int nrofila)
        {
            int Id = int.Parse(gvDetalleProcedimientos.Rows[nrofila].Cells[0].Text);

            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                var record = contexto.Detalle_Procedimiento.Where(s => s.id == Id).SingleOrDefault<Detalle_Procedimiento>();
                ddlProcedimiento.SelectedValue = record.id_procedimiento.ToString();
                ddlProducto.SelectedValue = record.id_producto.ToString();
                DateTime fecha = Convert.ToDateTime(record.fecha);
                txtFecha.Text = fecha.ToShortDateString();
                txtCantidad.Text = record.cantidad.ToString();
                txtValorCobrado.Text = record.valor_cobrado.ToString();
                hdfIdDetalleProcedimiento.Value = record.id.ToString();
            }
        }
        private void ActualizarDetalleProcedimiento()
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(hdfIdDetalleProcedimiento.Value);
                Detalle_Procedimiento rec = contexto.Detalle_Procedimiento.FirstOrDefault<Detalle_Procedimiento>(s => s.id == Id);
                rec.id_procedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
                rec.id_producto = Convert.ToInt32(ddlProducto.SelectedValue);
                rec.cantidad = Convert.ToInt32(txtCantidad.Text);
                string fecha = txtFecha.Text;
                rec.fecha = DateTime.Parse(fecha);
                rec.valor_cobrado = Convert.ToInt32(txtValorCobrado.Text);
                contexto.SaveChanges();
            }
        }

        private void LimpiarRegistros()
        {
            txtCantidad.Text = string.Empty;
            txtValorCobrado.Text = string.Empty;
            txtFecha.Text = string.Empty;
        }


        private void EliminarFila(int nrofila)
        {
            int Id = int.Parse(gvDetalleProcedimientos.Rows[nrofila].Cells[0].Text);
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                Detalle_Procedimiento rec = contexto.Detalle_Procedimiento.FirstOrDefault<Detalle_Procedimiento>(s => s.id == Id);
                contexto.Detalle_Procedimiento.Remove(rec);
                contexto.SaveChanges();
            }
        }



        protected void validarCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (BDAlissezEntities contexto = new BDAlissezEntities())
            {
                int Id = Convert.ToInt32(ddlProducto.SelectedValue);
                Producto pro = contexto.Productoes.FirstOrDefault<Producto>(s => s.id == Id);
                int cant = Convert.ToInt32(pro.cantidad_disponible);
                int cantidad= Convert.ToInt32(txtCantidad.Text);
                if (cantidad>cant)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
               

            }
        }

       
    }
}