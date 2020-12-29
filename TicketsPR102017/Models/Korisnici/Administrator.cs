using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models.Korisnici
{
    [Serializable]
    public class Administrator : Korisnik
    {
        public Administrator()
        {

        }
        public Administrator(string korisnickoIme, string lozinka, string ime, string prezime, DateTime datum) : base(korisnickoIme, lozinka, ime, prezime, datum)
        {
            this.Uloga = Enumeracija.Uloga.ADMINISTRATOR;
        }

    }
}