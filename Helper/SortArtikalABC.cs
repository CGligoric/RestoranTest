using RestoranTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Helper
{
    class SortArtikalABC : IComparer<Artikal>
    {
        public int Compare(Artikal x, Artikal y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            else
            {
                return x.Naziv.CompareTo(y.Naziv);
            }
        }
    }
}
