using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Models
{
    [System.Xml.Serialization.XmlInclude(typeof(Administrator))]
    [System.Xml.Serialization.XmlInclude(typeof(Prodavac))]
    [System.Xml.Serialization.XmlInclude(typeof(Kupac))]
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Enumeracija.Uloga Uloga { get; set; }
        public int BrojBodova { get; set; }
        public TipKorisnika Tip { get; set; }
        public Enumeracija.Status Obrisan { get; set; }
        public Enumeracija.Pol Pol { get; set; }

        public Korisnik()
        {

        }
   
        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, DateTime datum)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datum;
            BrojBodova = 0;
            Tip = new TipKorisnika(Enumeracija.TipPaketa.BRONZANI, 0, 100);
            Obrisan = Enumeracija.Status.AKTIVAN;
            

        }
    }
}