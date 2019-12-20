using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Tecnico = new HashSet<Tecnico>();
        }

        public int Usuarioid { get; set; }
        public string Suscripcion { get; set; }
        public double Precio { get; set; }
        public int? Duracion { get; set; }

        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
