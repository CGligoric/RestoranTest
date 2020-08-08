using RestoranTest.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranTest.Models
{
    class StavkaRacuna
    {
        public int Id { get; set; }
        public int aId { get; set; }
        public Artikal Artikal { get; set; }
        public int rId { get; set; }
        public int Kolicina { get; set; }

        public StavkaRacuna() { }

        public StavkaRacuna(int id, int aid, int rid, int kol)
        {
            Id = id;
            aId = aid;
            rId = rid;
            Kolicina = kol;

            Artikal = ArtikalDAO.GetById(Program.conn, aId);
        }

        public override string ToString()
        {
            return String.Format("ID artikla: {0} | Naziv: {1} | Cena: {2} | Kolicina: {3}", aId, Artikal.Naziv, Artikal.Cena, Kolicina);
        }
    }
}
