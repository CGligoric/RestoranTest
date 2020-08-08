using RestoranTest.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class Hrana : Artikal
    {
        public Artikal Artikal { get; set; }
        public TipHrane TipHrane { get; set; }
        public int artId { get; set; }
        public int tipId { get; set; }

        public Hrana() { } 
        public Hrana(int id, string naziv, int cena, int artid, int tipid) : base(id, naziv, cena)
        {
            artId = artid;
            tipId = tipid;
            TipHrane = TipHraneDAO.GetById(Program.conn, tipId);
            Artikal = ArtikalDAO.GetById(Program.conn, artId);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Tip: {0}", TipHrane.Naziv);
        }
    }
}
