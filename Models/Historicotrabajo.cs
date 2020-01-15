using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Historicotrabajo
    {
        public int Historicoid { get; set; }
        public int? Clienteid { get; set; }
        public int? Tecnicoid { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? Rankingid { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
