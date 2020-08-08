using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class Artikal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }

        public Artikal() { } 
        public Artikal(int id, string naziv, int cena)
        {
            Id = id;
            Naziv = naziv;
            Cena = cena;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Naziv : {1} | Cena: {2} RSD", Id, Naziv, Cena);
        }
    }
}
