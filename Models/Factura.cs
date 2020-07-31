using System;
using System.Collections.Generic;

namespace factura.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleProductosFactura = new HashSet<DetalleProductosFactura>();
        }

        public int FacturaId { get; set; }
        public string FacturaDescripcion { get; set; }
        public int? PersonaId { get; set; }

        public virtual Personas Persona { get; set; }
        public virtual ICollection<DetalleProductosFactura> DetalleProductosFactura { get; set; }
    }
}
