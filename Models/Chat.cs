using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Chatdetalle = new HashSet<Chatdetalle>();
        }

        public int Chatid { get; set; }
        public int Clienteid { get; set; }
        public int Tecnicoid { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        public virtual ICollection<Chatdetalle> Chatdetalle { get; set; }
    }
}
