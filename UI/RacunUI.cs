using RestoranTest.DAO;
using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.UI
{
    class RacunUI
    {
        static List<Racun> sviRacuni = RacunDAO.GetAll(Program.conn);

        private static void OsnovniMeni()
        {
            Console.WriteLine("Rad sa racunima opcije");
            Console.WriteLine("1 - ispisi sve racune");
            Console.WriteLine("2 - izdaj nov racun");
        }

        public static void KompletMeni()
        {
            bool nastavak = false;

            do
            {
                Console.Clear();
                OsnovniMeni();
                Console.WriteLine("Opcija: ");
                int opcija = Convert.ToInt32(Console.ReadLine());

                switch (opcija)
                {
                    case 1:
                        IspisiSve();
                        break;
                    case 2:
                        IzdajRacun();
                        break;
                    default:
                        break;
                }
            } while (nastavak);
        }

        public static void IspisiSve()
        {
            foreach (Racun r in sviRacuni)
            {
                Console.WriteLine(r.ToString());
            }
        }

        public static void IzdajRacun()
        {
            Console.WriteLine("Upisite ID stola: ");
            int stoId = Convert.ToInt32(Console.ReadLine());
            Sto sto = StoDAO.GetById(Program.conn, stoId);
            sto.Deleted = true;

            Console.WriteLine("Upisite broj artikla: ");
            int brArt = Convert.ToInt32(Console.ReadLine());
            List<StavkaRacuna> sveStavke = new List<StavkaRacuna>();

            Racun racun = new Racun();
            racun.Id = sviRacuni.Count + 1;
            racun.stoId = stoId;

            for (int i = 0; i < brArt; i++)
            {
                Console.WriteLine("Upisite ID artikla: ");
                int aId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesite kupljenu kolicinu: ");
                int kol = Convert.ToInt32(Console.ReadLine());

                sveStavke.Add(new StavkaRacuna(sveStavke.Count + 1, aId, sviRacuni.Count + 1, kol));
            }

            for (int i = 0; i < sveStavke.Count; i++)
            {
                Artikal artikal = ArtikalDAO.GetById(Program.conn, sveStavke[i].aId);
                racun.Cena += artikal.Cena * sveStavke[i].Kolicina;
            }

            RacunDAO.Add(Program.conn, racun);
            IspisRacuna(racun, sveStavke);

        }

        private static void IspisRacuna(Racun rac, List<StavkaRacuna> sveStavke)
        {
            Console.WriteLine("=======================");
            for (int i = 0; i < sveStavke.Count; i++)
            {
                Console.WriteLine(sveStavke[i].ToString());
            }
            Console.WriteLine("=======================");
            Console.WriteLine("ID: {0} | Ukupna cena: {1} | ID stola: {2} | Broj artikala: {3}", rac.Id, rac.Cena, rac.stoId, sveStavke.Count);
        }

    }
}
