using RestoranTest.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest
{
    class Program
    {
        public static SqlConnection conn;

        private static void LoadConnection()
        {
            try
            {
                string connectionStringZaPoKuci = "Data Source=.\\SQLEXPRESS;Initial Catalog=Restoran;Integrated Security=True;MultipleActiveResultSets=True";

                conn = new SqlConnection(connectionStringZaPoKuci);
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void OsnovniMeni()
        {
            Console.WriteLine("RestoranDB");
            Console.WriteLine("1 - rad sa artiklima");
            Console.WriteLine("2 - rad sa stolovima");
            Console.WriteLine("3 - rad sa racunima");
        }

        static void Main(string[] args)
        {
            LoadConnection();

            bool nastavak = false;

            do
            {
                Console.Clear();
                OsnovniMeni();
                Console.WriteLine("Unesite opciju:");
                int opcija = Convert.ToInt32(Console.ReadLine());

                switch (opcija)
                {
                    case 1:
                        ArtikalUI.IspisiKompletMeni();
                        break;
                    case 2:
                        StoUI.KompletMeni();
                        break;
                    case 3:
                        RacunUI.KompletMeni();
                        break;
                    default:
                        Console.WriteLine("Nevazeca komanda! Probajte ponovo.");
                        nastavak = true;
                        continue;
                }

                Console.WriteLine("Da li zelite da nastavite s radom nad podacima Restorana? d/n");
                string odg = Console.ReadLine();

                if (odg == "d")
                {
                    nastavak = true;
                }

            } while (nastavak);
        }
    }
}
