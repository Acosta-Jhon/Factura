using System;
using System.Collections.Generic;

namespace factura.Models
{
    public partial class Productos
    {
        public Productos()
        {
            DetalleProductosFactura = new HashSet<DetalleProductosFactura>();
        }

        public int ProductosId { get; set; }
        public string ProductosNombre { get; set; }
        public double? ProductosPrecio { get; set; }
        public int? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetalleProductosFactura> DetalleProductosFactura { get; set; }
    }
}
