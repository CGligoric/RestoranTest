using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class Pice : Artikal
    {
        public Artikal Artikal { get; set; }
        public double  Zapremina { get; set; }

        public Pice() { } 

        public Pice(int id, string naziv, int cena, double zapremina) : base(id, naziv, cena)
        {
            Zapremina = zapremina;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Zapremina: {0}L", Zapremina);
        }
    }
}
