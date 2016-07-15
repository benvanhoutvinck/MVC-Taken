using MVCBierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBierenApplication.Services
{
    public class BierService
    {
        private MVCBierenEntities db = new MVCBierenEntities();

        static BierService()
        {
          
        }
        public List<Bier> FindAll()
        {
            var bieren = db.Bieren;
            
            return bieren.ToList();
        }
        public Bier Read(int id)
        {
            return null;
        }
        public void Delete(int id)
        {
           
        }
        public void Add(Bier b)
        {
           
        }

       
    }
}