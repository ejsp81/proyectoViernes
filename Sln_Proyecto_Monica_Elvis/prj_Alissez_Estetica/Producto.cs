//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj_Alissez_Estetica
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Detalle_Procedimiento = new HashSet<Detalle_Procedimiento>();
        }
    
        public int id { get; set; }
        public int id_tipo_producto { get; set; }
        public int id_medida_producto { get; set; }
        public int precio_compra { get; set; }
        public int cantidad_producto { get; set; }
        public Nullable<int> cantidad_disponible { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Procedimiento> Detalle_Procedimiento { get; set; }
        public virtual Medida_Producto Medida_Producto { get; set; }
        public virtual Tipo_Producto Tipo_Producto { get; set; }
    }
}
