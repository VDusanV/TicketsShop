# TicketsShop
Web project that uses MVC technology.


Web programiranje – Specifikacija
projektnog zadatka
Primenjeno Softversko Inženjerstvo 2019/2020
Projektni zadatak

Specifikacija zahteva
Potrebno je realizovati veb aplikaciju za sistem koji podržava rezervaciju ulaznica za koncerte,
pozorišta, festivale i slične manifestacije (kao GIGS TIX ili tickets.rs aplikacije). Aplikaciju koriste
3 grupe (uloge) korisnika: Kupac, Prodavac, Administrator. Aplikacija rukuje sa sledećim
entitetima:
Korisnik
● Korisničko ime (jedinstveno)
● Lozinka
● Ime
● Prezime
● Pol
● Datum rođenja
● Uloga (Administrator, Prodavac, Kupac)
● SveKarteBezObziraNaStatus (ako je korisnik Kupac)
● Manifestacije (ako je korisnik Prodavac)
● Broj sakupljenih bodova (ako je korisnik Kupac)
● Tip korisnika
Tip korisnika
● Ime tipa (npr. Zlatni, Srebrni, Bronzani)
● Popust (procenat koji se koristi za obračunavanje cene karte prilikom kupovine)
● Traženi broj bodova (potreban broj bodova kako bi korisnik postao npr. Zlatni korisnik)Lokacija
● Geografska dužina
● Geografska širina
● Mesto održavanja
Mesto održavanja
● Adresa u formatu: ulica i broj, mesto/grad, poštanski broj
Slika 1.
Manifestacija
● Naziv
● Tip manifestacije (koncert, festival, pozorište, i slično)
● Broj mesta
● Datum i vreme održavanja
● Cena REGULAR karte
● Status (Aktivno ili Neaktivno)
● Mesto održavanja
● Poster manifestacije (slika)
Karta
● Jedinstveni identifikator karte (10 karaktera)
● Manifestacija za koju je rezervisana
● Datum i vreme manifestacije
● Cena
● Kupac (ime i prezime)
● Status (Rezervisana, Odustanak)
● Tip (VIP, REGULAR, FAN PIT)
Komentar
● Kupac karte koji je ostavio komentar
● Manifestacija na koju se komentar odnosi
● Tekst komentara
● Ocena (na skali od 1 do 5)Implementirati sledeće funkcionalnosti:
● Registracija - neregistrovan korisnik se registruje na aplikaciju popunjavajući polja koja
su za to predviđena i nakon toga postaje Kupac
● Administratori se pogramski učitavaju iz tekstualnog fajla i ne mogu se naknadno dodati.
Prodavce mogu kreirati samo administratori. Kupac ne može da postane
Prodavac.
● Prijavljivanje na sistem - neprijavljeni korisnik loguje se na sistem tako što unosi
korisnićko ime i lozinku korisnika za koji je registrovan. Nakon toga, korisnik je prijavljen i
može da izvršava aktivnosti predviđene njegovom ulogom.
● Svi ulogovani korisnici mogu da vide svoje profile i da menjaju svoje lične podatke.
● Administratori imaju pregled svih korisnika registrovanih na sistemu.
● Prodavac ima pregled svih svojih manifestacija, rezervisanih karata i kupaca koji su
rezervisali njihove karte.
Manifestacija
● Prikaz svih manifestacija u okviru početne strane koja je vidljiva ​svim tipovima
korisnika ​(uključujući i neregistrovane korisnike)​. ​Ovaj prikaz u okviru početne stranice
treba da prikaže sve događaje i to tako da su pri vrhu (na početku) oni najskoriji.
● Omogućiti pretragu ​svih​ manifestacija po sledećim kriterijumima:
○ Naziv manifestacije
○ Mesto održavanja
○ Datumu (može se zadati opseg od-do)
○ Lokaciji (korisnik zadaje naziv grada ili države)
○ Ceni (opseg od-do).
Prilikom prikaza rezultata pretrage voditi računa o tome da se prikažu sledeći podaci:
○ Naziv manifestacije
○ Tip manifestacije
○ Datum i vreme održavanja
○ Mesto održavanja
○ Poster manifestacije
○ Cena karte
○ Prosečna ocena manifestacije (ukoliko je ona završena, suprotno se ne
prikazuje).
U okviru pretrage pružiti mogućnost sortiranja i filtriranja rezultata. Sortiranje je potrebno
implementirati po rastućem ili opadajućem kriterijumu prema sledećim parametrima:
○ Naziv manifestacije
○ Datum i vreme održavanja
○ Ceni karte
○ Mesto održavanja,dok je filtriranje potrebno omogućiti po sledećim kriterijumima:
○ Tip manifestacije
○ Prikaz nerasprodatih manifestacija.
Izborom neke od prikazanih manifestacija, korisnik se prebacuje na prikaz te konkretne
manifestacije.
● Prikaz jedne manifestacije koji treba da prikaže osnovne informacije o svakoj
manifestaciji:
○ Naziv
○ Tip manifestacije
○ Broj mesta
○ Preostali broj karata
○ Datum i vreme održavanja
○ Cena karte
○ Status (Aktivno ili Neaktivno)
○ Mesto održavanja
○ Poster manifestacije (slika)
○ Ocena manifestacije (ukoliko ona postoji)
○ Komentare o manifestaciji (ukoliko oni postoje).
Prikaz mesta održavanja pored prikaza teksta lokacije u formatu definisanom unutar
entiteta ​Mesto održavanja, ​prikazati mapu ukoliko bude implementiran ​dodatni zadatak 1​.
● Prodavcima ​je dostupna funkcionalnost dodavanje novih manifestacija, pri čemu je
potrebno voditi računa da ne postoji već zakazana manifestacija u željenom vremenu na
željenoj lokaciji. Nakon kreiranja manifestacije, ona se nalazi u statusu ​Neaktivna. ​Da bi
manifestacija prešla u status ​Aktivna ​potrebno je da je ​Administrator ​odobri.
● Pored dodavanja novih manifestacija, omogućiti prodavcima funkcionalnost izmene
podataka o postojećim manifestacijama.
Karte
● Korisnici (Kupci)​ imaju opciju pregleda svih svojih karata u okviru svog korisničkog
profila. Kod pregleda ovih karata omogućiti pregled ​rezervisanih ​karata.
● Karte od kupca (bez obzira na status)​ je moguće pretražiti, filtrirati i sortirati. Pretraga se
vrši po sledećim kriterijumima:
○ Manifestaciji za koju je karta rezervisana
○ Ceni karte (cena u opsegu od-do)
○ Datumu održavanja manifestacije (od-do),
dok se sortiranje vrši (rastuće i opadajuće) po:
○ Imenu manifestacije za koju je karta rezervisana
○ Ceni karte
○ Datumu održavanja manifestacije,a filtriranje po:
○ Tipu karte
○ Statusu karte.
● Prodavcima ​je dostupan prikaz svih rezervisanih karata, dok je ​administratorima
dostupan prikaz karata svih mogućih statusa.
● Cena REGULAR karte je definisana prilikom kreiranja manifestacije. Cena FAN PIT
karte je 2 puta veća od cene REGULAR karte, a cena VIP karte je 4 puta veća od cene
REGULAR karte​.
● Kartu/-e za određene manifestacije mogu da rezervišu samo ​Kupci. ​Za bilo koju aktivnu
manifestaciju kod koje nisu rasprodate karte kupac može da izvrši ​rezervaciju karte.
Kupac ​može da rezerviše odjednom jednu ili više karata, pri čemu se sve one
vode na njega. Prilikom rezervacije, potrebno je pre nego što ​Kupac ​potvrdi svoju
rezervaciju prikazati korisniku ukupnu cenu i broj karata koje rezerviše (voditi računa o
obračunavanju popusta u skladu sa tipom korisnika).
Kada korisnik rezerviše kartu/-e, za svaku od njih dobija određeni broj bodova.
Ovaj broj bodova se za pojedinačnu kartu računa po sledećoj formuli:
broj_bodova = cena_jedne_karte/1000 * 133
● Kupac ​ima opciju da odustane od svoje rezervacije najkasnije 7 dana do početka
manifestacije. Ako se odustane od rezervacije gubi se broj bodova za svaku kartu koja
pripada rezervaciji prema sledećoj formuli:
broj_izgubljenih_bodova = cena_jedne_karte/1000 * 133 * 4
Komentari:
● Jednom kada manifestacija prođe (status karte je ​REZERVISANA ​i datum održavanja
manifestacije je u prošlosti), korisnik koji je rezervisao kartu/-e može da ostavi komentar
na manifestaciju koju je posetio i istu ujedno i oceni.
● Nakon što je komentar kreiran, on se ne prikazuje na stranici manifestacije dok god ga
Prodavac ​ne odobri (može i da ga odbije).
● Kupci​ mogu da vide komentare na manifestacije ​samo​ koje je ​prodavac ​odobrio.
● Prodavci i Administratori ​mogu da vide ​sve​ komentare (prihvaćene i odbijene).
Korisnici:
● Administrator ​ima mogućnost prikaza svih registrovanih korisnika sistema. Može da ih
pretražuje, filtrira i sortira. Pretraga se vrši po:
○ Imenu
○ Prezimenu
○ Korisničkom imenu
Sortiranje je potrebno implementirati u rastućem i opadajućem režimu, a moguće ga je
izvršiti prema sledećim parametrima:
○ Imenu
○ Prezimenu
○ Korisničkom imenu○ Broju sakupljenih bodova.
Filtriranje se vrši prema sledećim parametrima:
○ Ulozi
○ Tipu korisnika.
Realizovati kombinovanu pretragu manifestacija po prethodno navedenim kriterijumima u
pretrazi manifestacija.
Kombinovana ili višestruka pretraga znači da korisnik može da odabere više opcija po kojim će
da vrši pretragu. Npr. korisnik može da odabere da pretražuje po mestu održavanja, ceni i
datumu itd. (Slika 2.)
Slika 2.
Dodatne napomene:
1. Brisanje svih entiteta u sistemu je ​logičko​. Samo administratori imaju prava da brišu
entitete. Svi entiteti koji se mogu dodati, mogu se i obrisati.
2. U zavisnosti od konkretne implementacije, ​studenti mogu proizvoljno da prošire date
entitete ili dodavati druge.
3. Potrebno je da student samostalno definiše skalu bodova za Tipove korisnika (npr. da bi
korisnik postao Srebrni potrebno je da sakupi 3000 bodova (i tom prilikom ima npr.
popust od 3% prilikom svake kupovine), a da bi postao Zlatan potrebno je da sakupi
4000 bodova (i tom prilikom ima npr. popust od 5% prilikom svake kupovine)).
Dodatni zadaci za više ocene
1. Prilikom odabira lokacije koristiti OpenLayers mape (​https://openlayers.org/​) ili neku
alternativu mape za pretragu mesta održavanja manifestacije na osnovu lokacije ili
zadavanja lokacije prilikom kreiranja manifestacije.
2. Omogućiti administratorima prikaz svih “sumnjivih” korisnika koji često otkazuju svoje
rezervacije. Ukoliko korisnik (​Kupac​) izvrši više od 5 otkazivanja rezervacija karata u
periodu od mesec dana on se smatra sumnjivim i izdvaja se u okviru spiska takvih
korisnika. Omogućiti ​Administratoru ​da može da blokira ovakve korisnike.
3. Administratori imaju mogućnost blokiranja registrovanih korisnika (ako nisu
administrator). Blokiran korisnik ne može da se uloguje na svoj nalog i nema mogućnost
da izvršava bilo koju akciju u zavisnosti od svoje uloge.Ocenjivanje projektnog zadatka
