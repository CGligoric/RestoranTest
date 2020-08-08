using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class RacunDAO
    {
        public static List<Racun> GetAll(SqlConnection conn)
        {
            List<Racun> sviRacuni = new List<Racun>();

            try
            {
                string query = "SELECT * FROM racun";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    int cena = (int)r["cena"];
                    int stoId = (int)r["sto_id"];

                    sviRacuni.Add(new Racun(id, cena, stoId));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sviRacuni;
        }

        public static bool Add(SqlConnection conn, Racun rac)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO racun VALUES (@id,@cena,@sto_id)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", rac.Id);
                cmd.Parameters.AddWithValue("@cena", rac.Cena);
                cmd.Parameters.AddWithValue("@sto_id", rac.stoId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retVal;
        }
    }
}
