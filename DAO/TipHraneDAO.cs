using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.DAO
{
    class TipHraneDAO
    {
        public static TipHrane GetById(SqlConnection conn, int id)
        {
            TipHrane th = null;

            try
            {
                string query = "SELECT * FROM tip_hrane WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string naziv = (string)r["naziv"];

                    th = new TipHrane(id, naziv);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return th;
        }

        public static List<TipHrane> GetAll(SqlConnection conn, int id)
        {
            List<TipHrane> th = null;

            try
            {
                string query = "SELECT * FROM tip_hrane";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    string naziv = (string)r["naziv"];

                    th.Add(new TipHrane(id, naziv));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return th;
        }

        public static bool Add(SqlConnection conn, TipHrane th)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO tip_hrane VALUES (@id,@naziv)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", th.Id);
                cmd.Parameters.AddWithValue("@naziv", th.Naziv);

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

        public static bool Update(SqlConnection conn, TipHrane th)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE tip_hrane SET naziv=@naziv WHERE id = @id";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", th.Id);
                cmd.Parameters.AddWithValue("@naziv", th.Naziv);

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
                string query = "DELETE FROM tip_hrane WHERE id = " + id;
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
