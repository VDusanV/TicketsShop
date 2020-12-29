using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models.Korisnici
{
    [Serializable]
    public class Kupac : Korisnik
    {
        public List<Karta> RezervisaneKarte { get; set; }
        public Kupac()
        {

        }

        public Kupac(string korisnickoIme, string lozinka, string ime, string prezime, DateTime datum,Enumeracija.Pol p) : base(korisnickoIme, lozinka, ime, prezime, datum)
        {

            this.RezervisaneKarte = new List<Karta>();
            this.BrojBodova = 0;
            this.Uloga = Enumeracija.Uloga.KUPAC;
            this.Pol = p;
        }

    }
}