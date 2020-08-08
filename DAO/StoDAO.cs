using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class StoDAO
    {
        public static Sto GetById(SqlConnection conn, int id)
        {
            Sto sto = null;

            try
            {
                string query = "SELECT * FROM sto WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    int max = (int)r["max_osobe"];

                    sto = new Sto(id, max);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sto;
        }

        public static List<Sto> GetAll(SqlConnection conn)
        {
            List<Sto> sto = new List<Sto>();

            try
            {
                string query = "SELECT * FROM sto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    int max = (int)r["max_osobe"];

                    sto.Add(new Sto(id, max));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sto;
        }

        public static bool Add(SqlConnection conn, Sto sto)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO sto VALUES (@id,@max_osobe)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", sto.Id);
                cmd.Parameters.AddWithValue("@max_osobe", sto.MaxOsobe);

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

        public static bool Update(SqlConnection conn, Sto sto)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE sto SET max_osobe=@max_osobe WHERE id=@id";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", sto.Id);
                cmd.Parameters.AddWithValue("@max_osobe", sto.MaxOsobe);

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
                string query = "DELETE FROM sto WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);


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
