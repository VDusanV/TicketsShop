using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Controllers
{
    public class RegistracijaController : Controller
    {
        // GET: Registracija
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrujSe(string KorisnickoIme, string Lozinka, string Ime, string Prezime, DateTime DatumRodjenja, Enumeracija.Pol Pol)
        {

            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();

            Kupac k = new Kupac(KorisnickoIme, Lozinka, Ime, Prezime, DatumRodjenja, Pol);

            foreach (var item in korisnici)
            {
                if (item.Key == k.KorisnickoIme)
                {
                    ViewBag.Greska = "Korisnicko ime je vec zauzato";
                    return View("Index");
                }
            }
            if (KorisnickoIme.Trim() == "")
            {

                ViewBag.Greska = "Korisnicko ime ne sme biti prazno";
                return View("Index");
            }
            if (Lozinka.Trim() == "")
            {

                ViewBag.Greska = "Lozinka ne sme biti prazno";
                return View("Index");
            }
            if (Ime.Trim() == "")
            {

                ViewBag.Greska = "Ime ne sme biti prazno";
                return View("Index");
            }
            if (Prezime.Trim() == "")
            {

                ViewBag.Greska = "Prezime ne sme biti prazno";
                return View("Index");
            }
            

            korisnici.Add(k.KorisnickoIme,k);
            Baza.SacuvajKorisnike(korisnici);
           
            Session["korisnik"] = k;
            Session["kupac"] = k;
            return RedirectToAction("Index", "Home");

        }
    }
}