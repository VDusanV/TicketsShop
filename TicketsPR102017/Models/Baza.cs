using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Serialization;
using TicketsPR102017.Models.Korisnici;

namespace TicketsPR102017.Models
{
    public class Baza
    {
        public static Dictionary<string,Korisnik> UcitajKorisnike()
        {
            List<Korisnik> korisnici = new List<Korisnik>();

            Dictionary<string, Korisnik> korisniciDic = new Dictionary<string, Korisnik>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Korisnik>));

            TextReader tr = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + @"App_Data\Korisnici.xml");

            korisnici = (List<Korisnik>)serializer.Deserialize(tr);

            tr.Close();

            foreach (Korisnik k in korisnici)
            {
                korisniciDic.Add(k.KorisnickoIme, k);
            }

            return korisniciDic;
        }


        public static void SacuvajKorisnike(Dictionary<string, Korisnik> korisnici)
        {
            List<Korisnik> lista = korisnici.Values.ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Korisnik>));

            TextWriter tw = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + @"App_Data\Korisnici.xml");

            serializer.Serialize(tw, lista);

            tw.Close();
        }

        public static List<Manifestacija> UcitajManifestacije()
        {
            List<Manifestacija> ret = new List<Manifestacija>();
            Dictionary<string, Korisnik> korisnici = UcitajKorisnike();

            foreach (var item in korisnici.Values)
            {
                if(item.Uloga == Enumeracija.Uloga.PRODAVAC)
                {
                    foreach (var manif in (item as Prodavac).Manifestacije)
                    {
                        ret.Add(manif);
                    }
                }

            }
            return ret;
        }
        public static bool AzurirajManifestaciju(Manifestacija manif)
        {
            Dictionary<string ,Korisnik > korisnici = UcitajKorisnike();
            foreach (var item in korisnici)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.PRODAVAC) {
                    Prodavac p = (Prodavac)item.Value;
                    foreach (var m in p.Manifestacije)
                    {
                        if(m.Id == manif.Id)
                        {
                            p.Manifestacije.Remove(m);
                            p.Manifestacije.Add(manif);
                            SacuvajKorisnike(korisnici);
                            break;
                           
                        }
                    }
                }
                
            }
            Dictionary<string, Korisnik> korisnici2 = UcitajKorisnike();

            foreach (var item in korisnici2)
            {
                if (item.Value.Uloga == Enumeracija.Uloga.KUPAC)
                {
                    Kupac k = (Kupac)item.Value;
                    foreach (var karta in k.RezervisaneKarte)
                    {
                        if (karta.Manifestacija.Id == manif.Id)
                        {
                            karta.Manifestacija = manif;
                            karta.DatumManifestacije = manif.DatumOdrzavanja;
                            SacuvajKorisnike(korisnici2);
                            break;

                        }
                    }
                }
            }
            return true;
        }

    }
}