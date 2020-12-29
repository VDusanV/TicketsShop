using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class Komentar
    {
        public string Id { get; set; }

        public string Kupac { get; set; }
        public string NazivManifestacije { get; set; }
        public string Tekst { get; set; }
        public int Ocena { get; set; }
        public Enumeracija.TipKomentara Status { get; set; }

        public Komentar()
        {

        }
        public Komentar(string kupac,string manifestacija, string txt, int ocena)
        {
            Id = System.Guid.NewGuid().ToString();

            Kupac = kupac;
            NazivManifestacije = manifestacija;
            Tekst = txt;
            Ocena = ocena;
            Status = Enumeracija.TipKomentara.NEAKTIVAN;
        }
    }
}