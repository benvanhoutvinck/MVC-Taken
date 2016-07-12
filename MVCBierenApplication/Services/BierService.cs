using MVCBierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Services
{
    public class BierService
    {
        private static Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();

        static BierService()
        {
            bieren[1] =
            new Bier { ID = 1, Alcohol = 1.5f, Naam = "Duvel" };
            bieren[2] =
                new Bier { ID = 2, Alcohol = 5f, Naam = "Jupiler" };
            bieren[3] =
                new Bier { ID = 3, Alcohol = 8f, Naam = "Grimbergen" };
            bieren[4] =
                new Bier { ID = 4, Alcohol = 12f, Naam = "Westvleteren" };
        }
        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }
        public Bier Read(int id)
        {
            return bieren[id];
        }
        public void Delete(int id)
        {
            bieren.Remove(id);
        }
        public void Add(Bier b)
        {
            b.ID = bieren.Keys.Max() + 1;
            bieren.Add(b.ID, b);
        }
    }
}