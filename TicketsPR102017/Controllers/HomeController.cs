using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketsPR102017.Models;

namespace TicketsPR102017.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            manifestacije = manifestacije.OrderBy(l => l.DatumOdrzavanja).ToList();

            ViewBag.Manifestacije = manifestacije;
            return View();
        }

        public ActionResult Manifestacija(string ID)
        {
            List<Manifestacija> manifesta = Baza.UcitajManifestacije();
            Manifestacija man = new Manifestacija();
            foreach (var item in manifesta)
            {
                if (ID == item.Id)
                    man = item;
            }
            ViewBag.Manifestacija = man;
            return View();
        }
        public ActionResult Sortiraj(string sort, string redosled)
        {
            if (sort == null || redosled == null)
            {
                ViewBag.Manifestacije = Baza.UcitajManifestacije();

                return View("Index");
            }
            List<Manifestacija> manif = Baza.UcitajManifestacije();
            List<Manifestacija> ret = new List<Manifestacija>();
            if (sort == "Naziv")
            {
                ret = manif.OrderBy(l => l.Naziv).ToList();
            }
            else if (sort == "Datum")
            {
                ret = manif.OrderBy(l => l.DatumOdrzavanja).ToList();
            }
            else if (sort == "Cena")
            {
                ret = manif.OrderBy(l => l.CenaKarte).ToList();
            }
            else
            {
                ret = manif.OrderBy(l => l.MestoOdrzavanjaManif.Grad).ToList();
            }
            if (redosled == "Opadajucem")
                ret.Reverse();

            ViewBag.Manifestacije = ret;
            return View("Index");



        }
        public ActionResult Filtriraj(string tip, string nerasprodate)
        {
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            List<Manifestacija> ret = new List<Manifestacija>();

            if (tip != "")
            {
                if (tip == "Koncert")
                {
                    foreach (var item in manifestacije)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
                else if (tip == "Festival")
                {
                    foreach (var item in manifestacije)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
                else if (tip == "Pozoriste")
                {
                    foreach (var item in manifestacije)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
                else if (tip == "Slicno")
                {
                    foreach (var item in manifestacije)
                    {
                        if (item.Tip.ToString() == tip.ToUpper())
                            ret.Add(item);
                    }
                }
            }
            else
            {
                if (nerasprodate == "checked")
                {
                    foreach (var item in manifestacije)
                    {
                        if (item.BrojMesta > 0)
                            ret.Add(item);
                    }
                }
                else
                {
                    ret = manifestacije;
                }
            }
            ViewBag.Manifestacije = ret;

            return View("Index");

        }
        public ActionResult Pretraga(string naziv, string mestoodrzavanja, DateTime? datumod, DateTime? datumdo, double? cenaod, double? cenado)
        {
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            List<Manifestacija> ret = new List<Manifestacija>(manifestacije);
            if (naziv != "")
            {
                foreach (var item in manifestacije)
                {
                    if (naziv != item.Naziv)
                        ret.Remove(item);
                }
            }
            if (mestoodrzavanja != "")
            {
                foreach (var item in manifestacije)
                {
                    if (mestoodrzavanja != item.MestoOdrzavanjaManif.Grad)
                        ret.Remove(item);
                }
            }
            if (datumod != null)
            {
                foreach (var item in manifestacije)
                {
                    if (item.DatumOdrzavanja < datumod)
                        ret.Remove(item);

                }
            }
            if (datumdo != null)
            {
                foreach (var item in manifestacije)
                {
                    if (item.DatumOdrzavanja > datumdo)
                        ret.Remove(item);

                }
            }
            if (cenaod != null)
            {
                foreach (var item in manifestacije)
                {
                    if (item.CenaKarte < cenaod)
                        ret.Remove(item);
                }
            }
            if (cenado != null)
            {
                foreach (var item in manifestacije)
                {
                    if (item.CenaKarte > cenado)
                        ret.Remove(item);
                }
            }
            ViewBag.Manifestacije = ret;

            return View("Index");
        }

        public ActionResult Komentar(string ID)
        {
            ViewBag.mid = ID;
            return View();
        }
        public ActionResult komentarisi(string ime, string komentar, int ocena, string id)
        {
            if (ime.Trim() == "")
            {
                ViewBag.Greska = "Polje ime ne sme biti prazno";
                ViewBag.mid = id;

                return View("Komentar");

            }
            if (ocena < 1 || ocena>5)
            {
                ViewBag.Greska = "Ocena mora biti od 1 do 5";
                ViewBag.mid = id;

                return View("Komentar");

            }
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            foreach (var item in manifestacije)
            {
                if(id == item.Id)
                {
                    Komentar k = new Komentar(ime, item.Naziv, komentar, ocena);
                    item.Komentari.Add(k);
                    item.ZbirOcena += ocena;
                    item.BrojOcena++;
                    item.ProsecnaOcena = item.ZbirOcena / item.BrojOcena;
                    Baza.AzurirajManifestaciju(item);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult OdobriKomentar(string ID)
        {
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            foreach (var item in manifestacije)
            {
                foreach (var kom in item.Komentari)
                {
                    if(kom.Id == ID)
                    {
                        kom.Status = Enumeracija.TipKomentara.AKTIVAN;
                        Baza.AzurirajManifestaciju(item);

                        return RedirectToAction("Index");
                    }
                }

            }
            return RedirectToAction("Index");

        }
        public ActionResult OdbaciKomentar(string ID)
        {
            List<Manifestacija> manifestacije = Baza.UcitajManifestacije();
            foreach (var item in manifestacije)
            {
                foreach (var kom in item.Komentari)
                {
                    if (kom.Id == ID)
                    {
                        kom.Status = Enumeracija.TipKomentara.ODBIJEN;
                        Baza.AzurirajManifestaciju(item);
                        return RedirectToAction("Index");
                    }
                }

            }
            return RedirectToAction("Index");

        }
    }
}