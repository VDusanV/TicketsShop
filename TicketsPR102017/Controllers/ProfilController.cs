using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            if (Session["kupac"] != null)
            {
                Kupac k = (Kupac)Session["kupac"];
                List<Karta> karte = new List<Karta>();
                Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();

                foreach (var item in korisnici)
                {
                    if (k.KorisnickoIme == item.Value.KorisnickoIme)
                    {
                        Kupac kk = (Kupac)item.Value;
                        Session["kupac"] = item.Value;
                        ViewBag.Karte = kk.RezervisaneKarte;
                    }
                }


            }
            else
            {
                ViewBag.Karte = null;
            }
            
            return View(Session["korisnik"]);
        }
        public ActionResult Izmeni(string StaroKorisnicko, string KorisnickoIme, string Lozinka, string Ime, string Prezime, DateTime DatumRodjenja)
        {
            //treba implementirati ako izmenjeno korisnicko imevec postoji
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            Korisnik k = new Korisnik();
            foreach (var item in korisnici)
            {
                if(item.Value.KorisnickoIme == StaroKorisnicko)
                {
                    k = item.Value;
                    korisnici.Remove(item.Key);
                    break;
                }

            }
            k.KorisnickoIme = KorisnickoIme;
            k.Lozinka = Lozinka;
            k.Ime = Ime;
            k.Prezime = Prezime;
            k.DatumRodjenja = DatumRodjenja;
            korisnici.Add(k.KorisnickoIme,k);
            Session["korisnik"] = k;
            Baza.SacuvajKorisnike(korisnici);

            return RedirectToAction("Index");



        }

        public ActionResult Potvrda(string idManif,double cenaKarte, string imeKupca, int brojKarata, Enumeracija.TipKarte tipKarte)
        {
            ViewBag.idManif = idManif;
           
            ViewBag.imeKupca = imeKupca;
            ViewBag.brojKarata = brojKarata;
            ViewBag.tipKarte = tipKarte;
            if (tipKarte == Enumeracija.TipKarte.VIP)
                ViewBag.ukupnaCena =4* cenaKarte * brojKarata;
            else if (tipKarte == Enumeracija.TipKarte.FANPIT)
                ViewBag.ukupnaCena =2* cenaKarte * brojKarata;
            else
                ViewBag.ukupnaCena = cenaKarte * brojKarata;

            return View();
        }
            public ActionResult RezervisiKartu(string idManif,double cenaKarte, string imeKupca, int brojKarata, Enumeracija.TipKarte tipKarte)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            Kupac kupac;
                Kupac k = (Kupac)Session["kupac"];
            foreach (var item in korisnici)
            {
                if(k.KorisnickoIme == item.Value.KorisnickoIme)
                {
                    kupac = (Kupac)item.Value;
                    //dodati provere i greske
                    foreach (var item2 in manifestacije)
                    {
                        if(item2.Id == idManif)
                        {
                            if (item2.BrojMesta-brojKarata >= 0)
                            {
                                item2.BrojMesta -= brojKarata;
                               
                                    Karta karta = new Karta(item2, item2.DatumOdrzavanja, cenaKarte, imeKupca, brojKarata,tipKarte);
                                    kupac.RezervisaneKarte.Add(karta);

                                    item.Value.BrojBodova += (int)((item2.CenaKarte / 1000) * 133);

                                    Baza.SacuvajKorisnike(korisnici);
                                    Baza.AzurirajManifestaciju(item2);
                                    return RedirectToAction("Index", "Home");
                                
                                
                            }

                        }

                    }
                }
            }
            return RedirectToAction("Index");


        }

        public ActionResult Sortiraj(string sort, string redosled)
        {

            if (sort == null || redosled == null)
            {
                if (Session["kupac"] != null)
                {
                    Kupac kk = (Kupac)Session["kupac"];
                    List<Karta> kkarte = new List<Karta>();

                    foreach (var item in kk.RezervisaneKarte)
                    {
                        kkarte.Add(item);
                    }
                    ViewBag.Karte = kkarte;
                }
                else
                {
                    ViewBag.Karte = null;
                }

                return View("Index",Session["korisnik"]);
            }
            Kupac k = (Kupac)Session["kupac"];
            List<Karta> karte = new List<Karta>(k.RezervisaneKarte);
            List<Karta> ret = new List<Karta>();
            if (sort == "Naziv")
            {
                ret = karte.OrderBy(l => l.Manifestacija.Naziv).ToList();
            }
            else if (sort == "Datum")
            {
                ret = karte.OrderBy(l => l.DatumManifestacije).ToList();
            }
            else
            {
                ret = karte.OrderBy(l => l.CenaKarte).ToList();
            }
           
            if (redosled == "Opadajucem")
                ret.Reverse();

            ViewBag.Karte = ret;
            return View("Index",Session["korisnik"]);



        }

        public ActionResult Filtriraj(string tip, string rezervisane)
        {
            Kupac k = (Kupac)Session["kupac"];
            List<Karta> ret = new List<Karta>();

            if (tip != "")
            {
                if (tip == "Regular")
                {
                    foreach (var item in k.RezervisaneKarte)
                    {
                        if (item.TipKarte.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
                else if (tip == "Vip")
                {
                    foreach (var item in k.RezervisaneKarte)
                    {
                        if (item.TipKarte.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
                else
                {
                    foreach (var item in k.RezervisaneKarte)
                    {
                        if (item.TipKarte.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
               
            }
            else
            {
                if (rezervisane == "checked")
                {
                    foreach (var item in k.RezervisaneKarte)
                    {
                        if (item.StatusRezervacije.ToString()==Enumeracija.StatusKarte.REZERVISANA.ToString())
                            ret.Add(item);
                    }
                }
                else
                {
                    ret = k.RezervisaneKarte;
                }
            }
            ViewBag.Karte = ret;

            return View("Index",Session["korisnik"]);

        }

        public ActionResult Pretraga(string naziv,  DateTime? datumod, DateTime? datumdo, double? cenaod, double? cenado)
        {
            Kupac k = (Kupac)Session["kupac"];
            List<Karta> ret = new List<Karta>(k.RezervisaneKarte);
            if (naziv != "")
            {
                foreach (var item in k.RezervisaneKarte)
                {
                    if (naziv != item.Manifestacija.Naziv)
                        ret.Remove(item);

                }
            }
            if (datumod != null)
            {
                foreach (var item in k.RezervisaneKarte)
                {
                    if (item.DatumManifestacije < datumod)
                        ret.Remove(item);

                }
            }
            if (datumdo != null)
            {
                foreach (var item in k.RezervisaneKarte)
                {
                    if (item.DatumManifestacije > datumdo)
                        ret.Remove(item);

                }
            }
            if (cenaod != null)
            {
                foreach (var item in k.RezervisaneKarte)
                {
                    if (item.CenaKarte < cenaod)
                        ret.Remove(item);
                }
            }
            if (cenado != null)
            {
                foreach (var item in k.RezervisaneKarte)
                {
                    if (item.CenaKarte > cenado)
                        ret.Remove(item);
                }
            }
            ViewBag.Karte = ret;
            return View("Index", Session["korisnik"]);


        }
        public ActionResult Odustanak(string ID)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            Kupac k = (Kupac)Session["kupac"];
            Kupac kupac = (Kupac)korisnici[k.KorisnickoIme];
            foreach (var item in kupac.RezervisaneKarte)
            {
                if(item.Manifestacija.Id == ID)
                {
                    item.StatusRezervacije = Enumeracija.StatusKarte.ODUSTANAK;
                    kupac.BrojBodova -= (int)((item.CenaKarte / 1000) * 133 * 4);
                    Baza.SacuvajKorisnike(korisnici);
                    return RedirectToAction("Index");
                }

            }
            Baza.SacuvajKorisnike(korisnici);
        return RedirectToAction("Index");   
        }

    }
}