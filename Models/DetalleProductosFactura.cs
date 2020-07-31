using System;
using System.Collections.Generic;

namespace factura.Models
{
    public partial class DetalleProductosFactura
    {
        public int DetalleId { get; set; }
        public int? DetalleCantidad { get; set; }
        public double? DetalleIva { get; set; }
        public double? DetallePrecioUnitario { get; set; }
        public double? DetallePrecioTotal { get; set; }
        public double? DetalleSubTotal { get; set; }
        public int? FacturaId { get; set; }
        public int? ProductosId { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
