using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NMM.DAL;
using NMM.Models;


namespace NMM.DAL
{
    public class BreweryRepo : IBreweryRepository, IDisposable
    {
        private IEnumerable<Brewery> breweries;


        public BreweryRepo()
        {
            breweries = (IEnumerable<Brewery>)HttpContext.Current.Session["breweries"];
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            breweries = null;
        }

        public void Insert(Brewery brewery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brewery> SelectAll()
        {
            return breweries;
        }

        public Brewery SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brewery brewery)
        {
            throw new NotImplementedException();
        }
    }
}