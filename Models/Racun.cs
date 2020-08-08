using RestoranTest.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class Racun
    {
        public int Id { get; set; }
        public int Cena { get; set; }
        public int stoId { get; set; }

        public Racun() { } 
        public Racun(int id, int cena, int stoid)
        {
            Id = id;
            Cena = cena;
            stoId = stoid;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Cena: {1} | ID stola: {2}", Id, Cena, stoId);
        }

    }
}
