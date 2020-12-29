using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class TipKorisnika
    {
        public Enumeracija.TipPaketa ImePaketa { get; set; }
        public int Popust { get; set; }
        public double TrazeniBrojBodova { get; set; }

        public TipKorisnika(Enumeracija.TipPaketa ime, int popust, int bodovi)
        {
            this.ImePaketa = ime;
            this.Popust = popust;
            this.TrazeniBrojBodova = bodovi;
        }
        public TipKorisnika()
        {

        }
    }
}