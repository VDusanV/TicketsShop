using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsPR102017.Models
{
    public class Enumeracija
    {
        public enum Uloga
        {
            ADMINISTRATOR=0, PRODAVAC, KUPAC
        }
        public enum TipPaketa
        {
            BRONZANI=0, SREBRNI, ZLATNI
        }

        public enum Status
        {
            AKTIVAN=0,OBRISAN
        }
        public enum TipManifestacije
        {
            KONCERT=0,FESTIVAL,POZORISTE,SLICNO
        }
        public enum StatusManifestacije
        {
            AKTIVAN=0,NEAKTIVAN
        }
        public enum StatusKarte
        {
            REZERVISANA=0,ODUSTANAK
        }
        public enum TipKarte
        {
            VIP=0,REGULAR,FANPIT
        }
        public enum TipKomentara
        {
            NEAKTIVAN=0,AKTIVAN,ODBIJEN
        }
        public enum Pol
        {
            MUSKI=0,ZENSKI
        }
    }
}