using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class PiceDAO
    {
        public static Pice GetById(SqlConnection conn, int id)
        {
            Pice pice = null;

            try
            {
                string query = "SELECT * FROM hrana WHERE artikal_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    int zapremina = (int)r["zapremina"];

                    Artikal artikal = ArtikalDAO.GetById(Program.conn, id);

                    pice = new Pice(artikal.Id, artikal.Naziv, artikal.Cena, zapremina);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pice;
        }

        public static List<Pice> GetAll(SqlConnection conn)
        {
            List<Pice> pice = new List<Pice>();

            try
            {
                string query = "SELECT * FROM pice";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int aId = (int)r["artikal_id"];
                    double zapremina = (double)r["zapremina"];

                    Artikal artikal = ArtikalDAO.GetById(Program.conn, aId);

                    pice.Add(new Pice(artikal.Id, artikal.Naziv, artikal.Cena, zapremina));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pice;
        }

        public static bool Add(SqlConnection conn, Pice pice)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO hrana VALUES (@artikal_id,@zapremina)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@artikal_id", pice.Artikal.Id);
                cmd.Parameters.AddWithValue("@tip_id", pice.Zapremina);

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

        public static bool Update(SqlConnection conn, Pice pice)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE hrana SET zapremina=@zapremina WHERE artikal_id=@artikal_id";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@artikal_id", pice.Artikal.Id);
                cmd.Parameters.AddWithValue("@zapremina", pice.Zapremina);

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

        public static bool Delete(SqlConnection conn, int id)
        {
            bool retVal = false;

            try
            {
                string query = "DELETE FROM pice WHERE id = " + id;
                SqlCommand cmd = new SqlCommand();

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
