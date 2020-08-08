using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using RestoranTest.Models;

namespace RestoranTest.DAO
{
    class ArtikalDAO
    {
        public static Artikal GetById(SqlConnection conn, int id)
        {
            Artikal artikal = null;

            try
            {
                string query = "SELECT * FROM artikal WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string naziv = (string)r["naziv"];
                    int cena = (int)r["cena"];

                    artikal = new Artikal(id, naziv, cena);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return artikal;
        }

        public static List<Artikal> GetAll(SqlConnection conn)
        {
            List<Artikal> sviArtikli = new List<Artikal>();

            try
            {
                string query = "SELECT * FROM artikal";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string naziv = (string)r["naziv"];
                    int cena = (int)r["cena"];

                    sviArtikli.Add(new Artikal(id, naziv, cena));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sviArtikli;
        }

        public static bool Add(SqlConnection conn, Artikal art)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO artikal VALUES (@id,@naziv,@cena)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", art.Id);
                cmd.Parameters.AddWithValue("@naziv", art.Naziv);
                cmd.Parameters.AddWithValue("@cena", art.Cena);

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

        public static bool Update(SqlConnection conn, Artikal art)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE artikal SET naziv = @naziv, cena = @cena WHERE id = @id";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", art.Id);
                cmd.Parameters.AddWithValue("@naziv", art.Naziv);
                cmd.Parameters.AddWithValue("@cena", art.Cena);

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
                string query = "DELETE FROM artikal WHERE id = " + id;
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
