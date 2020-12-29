using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models.Korisnici
{
    [Serializable]
    public class Prodavac : Korisnik
    {

        public List<Manifestacija> Manifestacije { get; set; }

        public Prodavac()
        {

        }

        public Prodavac(string korisnickoIme, string lozinka, string ime, string prezime, DateTime datum) : base(korisnickoIme, lozinka, ime, prezime, datum)
        {
            this.Manifestacije = new List<Manifestacija>();
            this.Uloga = Enumeracija.Uloga.PRODAVAC;
        }
    }
}