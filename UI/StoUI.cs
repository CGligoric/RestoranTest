using RestoranTest.DAO;
using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.UI
{
    class StoUI
    {
        static List<Sto> sviStolovi = StoDAO.GetAll(Program.conn);

        public static void OsnovniMeni()
        {
            Console.WriteLine("Rad sa stolovima - opcije");
            Console.WriteLine("1 - Dodavanje novog stola");
            Console.WriteLine("2 - Brisanje stola");
        }

        public static void KompletMeni()
        {
            
            bool nastavak = false;

            do
            {
                Console.Clear();
                OsnovniMeni();
                Console.WriteLine("Unesite svoju opciju: ");
                int opcija = Convert.ToInt32(Console.ReadLine());

                switch (opcija)
                {
                    case 1:
                        Dodaj();
                        break;
                    case 2:
                        Obrisi();
                        break;
                    default:
                        Console.WriteLine("Nevazeca komanda. Probajte opet!");
                        nastavak = true;
                        continue;
                }
                Console.WriteLine("Zelite li da nastavite da radite sa podacima o stolovima? d/n");
                string odg = Console.ReadLine();

                if (odg == "d")
                {
                    nastavak = true;
                }
                else
                {
                    break;
                }
            } while (nastavak);
        }

        public static void Dodaj()
        {
            Console.WriteLine("Unesite broj osoba koji moze da sedne za ovaj sto: ");
            int max = Convert.ToInt32(Console.ReadLine());

            Sto sto = new Sto(sviStolovi.Count + 1, max);
            StoDAO.Add(Program.conn, sto);
        }

        public static void Obrisi()
        {
            Console.WriteLine("Unesite ID stola: ");
            int id = Convert.ToInt32(Console.ReadLine());

            StoDAO.Delete(Program.conn, id);
        }

    }
}
