using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class Manifestacija
    {
        public string Id { get; set; }
        public string Naziv { get; set; }
        public Enumeracija.TipManifestacije Tip { get; set; }
        public int BrojMesta { get; set; }
        public int Kapacitet { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public double CenaKarte { get; set; }
        public Enumeracija.StatusManifestacije Status { get; set; }
        public MestoOdrzavanja MestoOdrzavanjaManif { get; set; }
        public string Slika { get; set; }
        public List<Komentar> Komentari { get; set; }
        public double ProsecnaOcena { get; set; }
        public int BrojOcena { get; set; }
        public int ZbirOcena { get; set; }
        public Manifestacija()
        {
            MestoOdrzavanjaManif = new MestoOdrzavanja();
        }
        public Manifestacija(string naziv, Enumeracija.TipManifestacije tipManif, int brMesta, DateTime datumOdrzavanja, double cenaKarte, MestoOdrzavanja mestoOdrzavanja, string slika)
        {
            Id = System.Guid.NewGuid().ToString();
            Naziv = naziv;
            Tip = tipManif;
            BrojMesta = brMesta;
            Kapacitet= brMesta;
            DatumOdrzavanja = datumOdrzavanja;
            CenaKarte = cenaKarte;
            Status = Enumeracija.StatusManifestacije.NEAKTIVAN;
            MestoOdrzavanjaManif = mestoOdrzavanja;
            Slika = slika;
            Komentari = new List<Komentar>();
            ProsecnaOcena = 0;
            BrojOcena = 0;
            ZbirOcena = 0;

        }
    }
}