using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class HranaDAO
    {
        public static Hrana GetById(SqlConnection conn, int id)
        {
            Hrana hrana = null;

            try
            {
                string query = "SELECT * FROM hrana WHERE artikal_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    int thId = (int)r["tip_id"];

                    Artikal art = ArtikalDAO.GetById(Program.conn, id);

                    hrana = new Hrana(art.Id, art.Naziv, art.Cena, id, thId);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return hrana;
        }

        public static List<Hrana> GetAll(SqlConnection conn)
        {
            List<Hrana> hrana = new List<Hrana>();

            try
            {
                string query = "SELECT * FROM hrana";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int aId = (int)r["artikal_id"];
                    int thId = (int)r["tip_id"];

                    Artikal art = ArtikalDAO.GetById(Program.conn, aId);

                    hrana.Add(new Hrana(art.Id, art.Naziv, art.Cena, aId, thId));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return hrana;
        }

        public static bool Add(SqlConnection conn, Hrana hrana)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO hrana VALUES (@artikal_id,@tip_id)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@artikal_id", hrana.Artikal.Id);
                cmd.Parameters.AddWithValue("@tip_id", hrana.TipHrane.Id);

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

        public static bool Update(SqlConnection conn, Hrana hrana)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE hrana SET tip_id=@tip_id WHERE artikal_id=@artikal_id";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@artikal_id", hrana.Artikal.Id);
                cmd.Parameters.AddWithValue("@tip_id", hrana.tipId);

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
                string query = "DELETE FROM hrana WHERE id = " + id;
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
