using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class Karta
    {
        public string ID { get; set; }
        public Manifestacija Manifestacija { get; set; }
        public DateTime DatumManifestacije { get; set; }
        public double CenaKarte { get; set; }
        public string ImePrezimeKupca { get; set; }
        public int BrojKarata { get; set; }
        public Enumeracija.StatusKarte StatusRezervacije { get; set; }
        public Enumeracija.TipKarte TipKarte { get; set; }
        public Enumeracija.Status StatusKarte { get; set; }

        public Karta()
        {

        }

        public Karta(Manifestacija manifestacija, DateTime datum, double cena, string imeKupca,int brojKarata, Enumeracija.TipKarte tipKarte )
        {
            ID = System.Guid.NewGuid().ToString();
            Manifestacija = manifestacija;
            DatumManifestacije = datum;
            CenaKarte = cena;
            ImePrezimeKupca = imeKupca;
            StatusRezervacije = Enumeracija.StatusKarte.REZERVISANA;
            TipKarte = tipKarte;
            StatusKarte = Enumeracija.Status.AKTIVAN;
            BrojKarata = brojKarata;

        }


    }
}