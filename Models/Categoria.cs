using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Tecnico = new HashSet<Tecnico>();
        }

        public int Categoriaid { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
