using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class TipHrane
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public TipHrane() { } 
        public TipHrane(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }
    }
}
