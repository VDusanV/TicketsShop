using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Karta> karte = new List<Karta>();
            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {
                        
                                karte.Add(karta);
                       

                    }
                }

            }
            ViewBag.KarteAdmin = karte;



            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            ViewBag.AdminManif = manifestacije;
            return View(korisnici);
        }
        public ActionResult Pretraga(string ime, string prezime, string korisnicko)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Karta> karte = new List<Karta>();
            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {

                        karte.Add(karta);


                    }
                }

            }
            ViewBag.KarteAdmin = karte;


            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            Dictionary<string, Korisnik> ret = new Dictionary<string, Korisnik>(korisnici);
            if(ime != "")
            {
                foreach (var item in korisnici)
                {
                    if (ime != item.Value.Ime)
                        ret.Remove(item.Key);
                }
            }
            if (prezime != "")
            {
                foreach (var item in korisnici)
                {
                    if (ime != item.Value.Prezime)
                        ret.Remove(item.Key);
                }
            }
            if (korisnicko != "")
            {
                foreach (var item in korisnici)
                {
                    if (ime != item.Value.KorisnickoIme)
                        ret.Remove(item.Key);
                }
            }
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();

            ViewBag.AdminManif = manifestacije;
            return View("Index",ret);
        }




        public ActionResult Sortiraj(string sort, string redosled)
        {
            if (sort == null || redosled == null)
            {
                return RedirectToAction("Index");
            }
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            List<Korisnik> list = new List<Korisnik>(korisnici.Values);
            Dictionary<string, Korisnik> ret = new Dictionary<string, Korisnik>();
            if(sort == "Ime")
            {
                list = list.OrderBy(l => l.Ime).ToList();
                
            }
            else if (sort == "Prezime")
            {
                list = list.OrderBy(l => l.Prezime).ToList();

            }
            else if (sort == "Korisnicko")
            {
                list = list.OrderBy(l => l.KorisnickoIme).ToList();

            }
            else
            {
                list = list.OrderBy(l => l.BrojBodova).ToList();

            }
            if (redosled == "Opadajucem")
                list.Reverse();




            List<Karta> karte = new List<Karta>();
            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {

                        karte.Add(karta);


                    }
                }

            }
            ViewBag.KarteAdmin = karte;
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();

            ViewBag.AdminManif = manifestacije;


            ret = list.ToDictionary(l => l.KorisnickoIme, l => l);

            return View("Index", ret);
        }


        public ActionResult Filtriraj(string tip, string uloga)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            Dictionary<string, Korisnik> ret = new Dictionary<string, Korisnik>();
            if(tip != "")
            {
                if (tip == "Bronzani")
                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Tip.ImePaketa.ToString() == tip.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
                else if (tip == "Srebrni")
                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
                else if (tip == "Zlatni")

                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
            }
            else if(uloga != "")
            {
                if (uloga == "Kupac")
                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Uloga.ToString() == uloga.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
                else if (uloga == "Prodavac")
                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Uloga.ToString() == uloga.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
                else if (uloga == "Admin")

                {
                    foreach (var item in korisnici.Values)
                    {
                        if (item.Uloga.ToString() == uloga.ToUpper())
                            ret.Add(item.KorisnickoIme, item);
                    }
                }
            }



            List<Karta> karte = new List<Karta>();
            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {

                        karte.Add(karta);


                    }
                }

            }
            ViewBag.KarteAdmin = karte;
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();

            ViewBag.AdminManif = manifestacije;
            return View("Index", ret);

        }

        public ActionResult RegistracijaProdavca(string KorisnickoIme, string Lozinka, string Ime, string Prezime, DateTime DatumRodjenja)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();

            Prodavac k = new Prodavac(KorisnickoIme, Lozinka, Ime, Prezime, DatumRodjenja);

            foreach (var item in korisnici)
            {
                if (item.Key == k.KorisnickoIme)
                {
                    //implementacija kada postoji vec korisnik
                    return RedirectToAction("About", "Home");
                }
            }

            korisnici.Add(k.KorisnickoIme, k);
            Baza.SacuvajKorisnike(korisnici);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult AktivirajManifestaciju(string ID)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();

            foreach (var item in korisnici)
            {
                if (item.Value.Uloga.ToString() == "PRODAVAC")
                {
                    Prodavac p = (Prodavac)item.Value;
                    foreach (var m in p.Manifestacije)
                    {
                        if (m.Id == ID)
                        {
                            if(m.Status == Enumeracija.StatusManifestacije.NEAKTIVAN)
                                 m.Status = Enumeracija.StatusManifestacije.AKTIVAN;
                            else
                                m.Status = Enumeracija.StatusManifestacije.NEAKTIVAN;

                            break;
                        }
                    }
                }
            }
            Baza.SacuvajKorisnike(korisnici);
            return RedirectToAction("Index");
        
        }
        public ActionResult IzbrisiKorisnika(string korisnicko)
        {
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            foreach (var item in korisnici)
            {
                if(item.Key == korisnicko)
                {
                    if(item.Value.Obrisan == Enumeracija.Status.AKTIVAN)
                        item.Value.Obrisan = Enumeracija.Status.OBRISAN;
                    else
                        item.Value.Obrisan = Enumeracija.Status.AKTIVAN;
                    break;
                }
            }
            Baza.SacuvajKorisnike(korisnici);
            return RedirectToAction("Index");
        }
    
    }
}