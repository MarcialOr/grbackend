using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Maestroranking
    {
        public Maestroranking()
        {
            Cliente = new HashSet<Cliente>();
            Tecnico = new HashSet<Tecnico>();
        }

        public int Rankingid { get; set; }
        public int De { get; set; }
        public int Para { get; set; }
        public int Valoracion { get; set; }
        public string Comentario { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
