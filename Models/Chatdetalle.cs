using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Chatdetalle
    {
        public int Chatdetalleid { get; set; }
        public int Chatid { get; set; }
        public string Mensaje { get; set; }
        public string Dueno { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
