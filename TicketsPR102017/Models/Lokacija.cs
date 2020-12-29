using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class Lokacija
    {
        public double GeografskaDuzina { get; set; }
        public double GeografskaSirina { get; set; }
        public MestoOdrzavanja MestoOdrzavanja { get; set; }

        public Lokacija()
        {

        }
        public Lokacija(double duzina, double sirina, MestoOdrzavanja mesto)
        {
            this.GeografskaDuzina = duzina;
            this.GeografskaSirina = sirina;
            this.MestoOdrzavanja = mesto;
        }
    }
}