using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            Chat = new HashSet<Chat>();
            Historicotrabajo = new HashSet<Historicotrabajo>();
        }

        public int Tecnicoid { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Sobremi { get; set; }
        public int? Rankingid { get; set; }
        public double? Presupuesto { get; set; }
        public int Usuarioid { get; set; }
        public int? Categoriaid { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Path { get; set; }
        public int? Telefono { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Maestroranking Ranking { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<Historicotrabajo> Historicotrabajo { get; set; }
    }
}
