using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Helper
{
    class SortArtikalCena : IComparer<Artikal>
    {
        public int Compare(Artikal x, Artikal y)
        {
            if (x.Cena > y.Cena)
            {
                return 1;
            }
            else if (x.Cena < y.Cena)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
