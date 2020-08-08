using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class StavkaRacunaDAO
    {
        public static List<StavkaRacuna> GetAll(SqlConnection conn)
        {
            List<StavkaRacuna> sveStavke = new List<StavkaRacuna>();

            try
            {
                string query = "SELECT * FROM stavka_racuna";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    int artId = (int)r["artikal_id"];
                    int racId = (int)r["racun_id"];
                    int kol = (int)r["kolicina"];

                    sveStavke.Add(new StavkaRacuna(id, artId, racId, kol));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sveStavke;
        }

    }
}
