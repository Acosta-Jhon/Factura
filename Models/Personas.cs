using System;
using System.Collections.Generic;

namespace factura.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Factura = new HashSet<Factura>();
        }

        public int PersonaId { get; set; }
        public string PersonaNombre { get; set; }
        public string PersonaApellido { get; set; }
        public string PersonaEmail { get; set; }
        public DateTime? PersonaFechaNacimiento { get; set; }
        public string PersonaTelefono { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
