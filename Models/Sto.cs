using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class Sto
    {
        public int Id { get; set; }
        public int MaxOsobe { get; set; }
        public bool Deleted { get; set; }

        public Sto() { }

        public Sto(int id, int mo, bool del = false)
        {
            Id = id;
            MaxOsobe = mo;
            Deleted = del;
        }
    }
}
