﻿using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Chat = new HashSet<Chat>();
            Historicotrabajo = new HashSet<Historicotrabajo>();
        }

        public int Clienteid { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Sobremi { get; set; }
        public int? Rankingid { get; set; }
        public int? Telefono { get; set; }
        public string Path { get; set; }

        public virtual Maestroranking Ranking { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<Historicotrabajo> Historicotrabajo { get; set; }
    }
}
