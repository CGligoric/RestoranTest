using RestoranTest.DAO;
using RestoranTest.Helper;
using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.UI
{
    class ArtikalUI
    {
        public static List<Artikal> sviArtikli = ArtikalDAO.GetAll(Program.conn);
        public static List<Hrana> svaHrana = HranaDAO.GetAll(Program.conn);
        public static List<Pice> svoPice = PiceDAO.GetAll(Program.conn);
        public static void IspisiOsnovniMeni()
        {
            Console.WriteLine("Rad sa artiklima opcije");
            Console.WriteLine("1 - ispisivanje artikla po ID");
            Console.WriteLine("2 - ispisivanje svih artikala");
            Console.WriteLine("3 - dodavanje novog artikla");
            Console.WriteLine("4 - brisanje artikla");
        }

        public static void IspisiKompletMeni()
        {
            bool nastavak = false;

            do
            {
                Console.Clear();
                IspisiOsnovniMeni();

                Console.WriteLine("Opcija: ");
                int opcija = Convert.ToInt32(Console.ReadLine());

                switch (opcija)
                {
                    case 1:
                        IspisiPoID();
                        break;
                    case 2:
                        IspisiSve();
                        break;
                    case 3:
                        Dodaj();
                        break;
                    case 4:
                        Obrisi();
                        break;
                    default:
                        Console.WriteLine("Nevazeca komanda! Probajte ponovo.");
                        nastavak = true;
                        continue;
                }
                Console.ReadLine();
                Console.WriteLine("Da li zelite da nastavite s radom nad podacima artikala? d/n");
                string odg = Console.ReadLine();

                if (odg == "d")
                {
                    nastavak = true;
                }

            } while (nastavak);
        }

        public static void IspisiPoID()
        {
            Console.WriteLine("Upisite ID artikla koji Vas zanima:");
            int id = Convert.ToInt32(Console.ReadLine());

            Artikal art = ArtikalDAO.GetById(Program.conn, id);
            Console.WriteLine(art.ToString());

            for (int i = 0; i < svaHrana.Count; i++)
            {
                if (art.Id == svaHrana[i].Artikal.Id)
                {
                    Console.WriteLine(svaHrana[i].ToString());
                }
            }
            for (int i = 0; i < svoPice.Count; i++)
            {
                if (art.Id == svoPice[i].Artikal.Id)
                {
                    Console.WriteLine(svoPice[i].ToString());
                }

            }
        }

        public static void IspisiSve()
        {
            Console.WriteLine("Da li zelite da se artikli ispisu po ceni ili po abecedi? c/a");
            string odg = Console.ReadLine();

            if (odg == "c")
            {
                SortArtikalCena sortiraj = new SortArtikalCena();

                svaHrana.Sort(sortiraj);
                svoPice.Sort(sortiraj);

                IspisiArtikle();
            }

            else
            {
                SortArtikalABC sortiraj = new SortArtikalABC();

                svaHrana.Sort(sortiraj);
                svoPice.Sort(sortiraj);

                IspisiArtikle();
            }
        }

        private static void IspisiArtikle()
        {
            Console.WriteLine("Hrana: ");
            foreach (Hrana h in svaHrana)
            {
                Console.WriteLine(h.ToString());
            }

            Console.WriteLine("Pice: ");
            foreach (Pice p in svoPice)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static void Dodaj()
        {
            Console.WriteLine("Upisite naziv artikla: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Upisite cenu artikla: ");
            int cena = Convert.ToInt32(Console.ReadLine());

            Artikal art = new Artikal(sviArtikli.Count + 1, naziv, cena);

            Console.WriteLine("Upisite da li je u pitanju nova hrana ili pice h/p: ");
            string hp = Console.ReadLine();

            if (hp.Equals("h"))
            {
                Console.WriteLine("Unesite i vrstu hrane u koju spada ovaj obrok. Dostupni su sledeci tipovi: ");
                List<TipHrane> sviTipovi = new List<TipHrane>();

                foreach (TipHrane th in sviTipovi)
                {
                    Console.WriteLine(th.ToString());
                }

                Console.WriteLine("Ako ovaj obrok ne spada ni u jedan od ovih tipova, da li zelite da napravite nov tip? Unesite \"d\" ako zelite ili ID tipa ako ne zelite.");
                string odg = Console.ReadLine();
                if (odg == "d")
                {
                    Console.WriteLine("Upisite naziv: ");
                    string nazivTH = Console.ReadLine();

                    TipHrane th = new TipHrane(sviTipovi.Count, nazivTH);
                    TipHraneDAO.Add(Program.conn, th);

                    Hrana h = new Hrana(svaHrana.Count + 1, naziv, cena, art.Id, th.Id);
                }
                else
                {
                    int iodg = Convert.ToInt32(odg);
                    TipHrane th = TipHraneDAO.GetById(Program.conn, iodg);
                    Hrana h = new Hrana(svaHrana.Count + 1, naziv, cena, art.Id, th.Id);
                }
            }

            else
            {
                Console.WriteLine("Unesite zapreminu ovog pica u L: ");
                double l = Convert.ToDouble(Console.ReadLine());

                Pice pice = new Pice(svoPice.Count + 1, naziv, cena, l);
                PiceDAO.Add(Program.conn, pice);
            }
        }

        public static void Obrisi() 
        {
            Console.WriteLine("Unesite ID artikla koji zelite da obrisete");
            int idA = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < svaHrana.Count; i++)
            {
                if (svaHrana[i].Artikal.Id == idA)
                {
                    HranaDAO.Delete(Program.conn, svaHrana[i].Id);
                }
            }

            for (int i = 0; i < svoPice.Count; i++)
            {
                if (svoPice[i].Artikal.Id == idA)
                {
                    PiceDAO.Delete(Program.conn, svoPice[i].Id);
                }
            }
        }
    }
}
