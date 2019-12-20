using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Mensaje
    {
        public int Mensajeid { get; set; }
        public int? Usuarioid { get; set; }
        public string Mensaje1 { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Chatid { get; set; }
    }
}
