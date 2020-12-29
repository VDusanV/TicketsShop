using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class MestoOdrzavanja
    {
        public string UlicaBroj { get; set; }
        public string Grad { get; set; }
        public int? PostanskiBroj { get; set; }

        public MestoOdrzavanja()
        {
            UlicaBroj = "";
            Grad = "";
            PostanskiBroj = 0;
        }
        public MestoOdrzavanja(string ulicaIbroj, string grad, int postanskibroj)
        {
            this.UlicaBroj = ulicaIbroj;
            this.Grad = grad;
            this.PostanskiBroj = postanskibroj;
        }

    }
}