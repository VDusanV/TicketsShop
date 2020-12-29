using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Controllers
{
    public class LogovanjeController : Controller
    {
        // GET: Logovanje
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string KorisnickoIme, string Lozinka)
        {
            if (KorisnickoIme == "" || Lozinka=="")
            {
                ViewBag.Greska = "Polja ne smeju biti prazna";
                return View("Index");
            }
            Dictionary<string, Korisnik> korisnici = Baza.UcitajKorisnike();
            foreach (var item in korisnici.Values)
            {
                if (item.KorisnickoIme == KorisnickoIme && item.Lozinka == Lozinka && item.Obrisan == Enumeracija.Status.AKTIVAN)
                {
                    Session["korisnik"] = item;
                    if (item.Uloga == Enumeracija.Uloga.KUPAC)
                        Session["kupac"] = item;
                    if (item.Uloga == Enumeracija.Uloga.ADMINISTRATOR)
                        Session["admin"] = item;
                    if (item.Uloga == Enumeracija.Uloga.PRODAVAC)
                        Session["prodavac"] = (Prodavac)item;
                    return RedirectToAction("Index", "Home");

                }
                
            }

            ViewBag.Greska = "Pogresna sifra ili korisnicko ime";
            return View("Index");
            //Implementacija kad ne postoji korinsik
            
        }
        public ActionResult Logout()
        {
            Session["kupac"] = null;
            Session["prodavac"] = null;
            Session["korisnik"] = null;
            Session["admin"] = null;
            return RedirectToAction("Index", "Home");

        }

    }
}