using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Controllers
{
    public class ProdavacController : Controller
    {
        // GET: Prodavac
        public ActionResult Index()
        {
            if (Session["prodavac"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.IzmenjenaManif = new Manifestacija();
            Prodavac k = (Prodavac)Session["prodavac"];
            ViewBag.ProdManif = k.Manifestacije;

            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
            List<Karta> karte = new List<Karta>();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {
                        foreach (var manif in k.Manifestacije)
                        {
                            if (manif.Id == karta.Manifestacija.Id && karta.StatusRezervacije == Enumeracija.StatusKarte.REZERVISANA)
                            {
                                karte.Add(karta);
                            }
                        }

                    }
                }

            }
            ViewBag.KarteProdavca = karte;

            return View();
        }
        public ActionResult DodajManifestaciju(string naziv, Enumeracija.TipManifestacije tipManifestacije, int brojmesta, DateTime datumodrzavanja, double cenakarte, string grad, string ulicaibroj, int postanskibroj, string slika, string id)
        {
           if(Provera(naziv,tipManifestacije,brojmesta,datumodrzavanja,cenakarte,grad,ulicaibroj,postanskibroj,slika,id)== false)
            {
                ViewBag.IzmenjenaManif = new Manifestacija();
                Prodavac k = (Prodavac)Session["prodavac"];
                ViewBag.ProdManif = k.Manifestacije;

                Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();
                List<Karta> karte = new List<Karta>();
                foreach (var item in koriscnici)
                {
                    if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                    {
                        Kupac kupac = (Kupac)item.Value;
                        foreach (var karta in kupac.RezervisaneKarte)
                        {
                            foreach (var manif in k.Manifestacije)
                            {
                                if (manif.Id == karta.Manifestacija.Id && karta.StatusRezervacije == Enumeracija.StatusKarte.REZERVISANA)
                                {
                                    karte.Add(karta);
                                }
                            }

                        }
                    }

                }
                ViewBag.KarteProdavca = karte;

                return View("Index");
            }

            MestoOdrzavanja mesto = new MestoOdrzavanja(ulicaibroj, grad, postanskibroj);
            Manifestacija manifestacija = new Manifestacija(naziv,tipManifestacije,brojmesta,datumodrzavanja,cenakarte,mesto,slika);

            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            Prodavac pro = (Prodavac)Session["prodavac"];
            if (id != "")
            {

                foreach (var item in pro.Manifestacije)
                {
                    if (item.Id == id)
                    {
                        manifestacija.Id = id;
                        manifestacija.Komentari = item.Komentari;
                        manifestacija.BrojOcena = item.BrojOcena;
                        manifestacija.ProsecnaOcena = item.ProsecnaOcena;
                        manifestacija.ZbirOcena = item.ZbirOcena;
                        pro.Manifestacije.Remove(item);
                        break;
                    }
                }
            }
            pro.Manifestacije.Add(manifestacija);

            korisnici[pro.KorisnickoIme] = pro;

            Baza.SacuvajKorisnike(korisnici);
            Baza.AzurirajManifestaciju(manifestacija);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult IzmeniManifestaciju (string ID)
        {
            List<Manifestacija> maniff = Baza.UcitajManifestacije();
            foreach (var item in maniff)
            {
                if(item.Id == ID)
                {
                    ViewBag.IzmenjenaManif = item;
                    break;
                }
            }
            Prodavac k = (Prodavac)Session["prodavac"];
            ViewBag.ProdManif = k.Manifestacije;

            Dictionary<string, Korisnik> koriscnici = Baza.UcitajKorisnike();

            List<Karta> karte = new List<Karta>();
            foreach (var item in koriscnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac kupac = (Kupac)item.Value;
                    foreach (var karta in kupac.RezervisaneKarte)
                    {
                        foreach (var manif in k.Manifestacije)
                        {
                            if (manif.Id == karta.Manifestacija.Id && karta.StatusRezervacije == Enumeracija.StatusKarte.REZERVISANA)
                            {
                                karte.Add(karta);
                            }
                        }

                    }
                }

            }
            ViewBag.KarteProdavca = karte;



            return View("Index");
        }
        [NonAction]
        public bool Provera(string naziv, Enumeracija.TipManifestacije tipManifestacije, int brojmesta, DateTime datumodrzavanja, double cenakarte, string grad, string ulicaibroj, int postanskibroj, string slika, string id)
        {
            if (naziv.Trim() == "")
            {
                ViewBag.Greska = "Prazano polje imena";
                return false;
            }
            if (brojmesta<0)
            {
                ViewBag.Greska = "Broj mesta ne sme biti negativan";
                return false;
            }
            if (DateTime.Compare(datumodrzavanja,DateTime.Now)<0)
            {
                ViewBag.Greska = "Datum rezervacije ne sme biti u proslosti";
                return false;
            }
            if (cenakarte < 0)
            {
                ViewBag.Greska = "Cena karte ne sme biti negativana";
                return false;
            }
            if (grad.Trim() == "")
            {
                ViewBag.Greska = "Prazano polje grad";
                return false;
            }
            if (ulicaibroj.Trim() == "")
            {
                ViewBag.Greska = "Prazano polje ulica i broj";
                return false;
            }
            if (postanskibroj<0)
            {
                ViewBag.Greska = "Pogresan postanski broj";
                return false;
            }

            return true;
        }
     
    }
}