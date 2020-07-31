using System;
using System.Collections.Generic;

namespace factura.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Productos>();
        }

        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
