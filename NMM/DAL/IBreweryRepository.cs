using NMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMM.DAL
{
    public interface IBreweryRepository
    {
        IEnumerable<Brewery> SelectAll();
        Brewery SelectOne(int id);
        void Insert(Brewery brewery);
        void Update(Brewery brewery);
        void Delete(int id);
    }
}