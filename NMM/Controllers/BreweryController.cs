using NMM.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMM.DAL;

namespace NMM.Controllers
{
    public class BreweryController : Controller
    {
        // GET: Brewery
        public ActionResult Index(string sortOrder)
        {
            IEnumerable<Brewery> breweries;

            BreweryRepo breweryRepo = new BreweryRepo();

            ViewBag.Cities = ListOfCities();
              
            using (breweryRepo)
            {
                breweries = breweryRepo.SelectAll() as IList<Brewery>;
            }

            switch (sortOrder)
            {
                case "Name":
                    breweries = breweries.OrderBy(Brewery => Brewery.Name);
                    break;
                case "City":
                    breweries = breweries.OrderBy(Brewry => Brewry.City);
                    break;
                case "URL":
                    breweries = breweries.OrderBy(Brewry => Brewry.URL);
                    break;
            }
            return View(breweries);
        }
        [HttpPost]
        public ActionResult Index(string searchCriteria, string cityFilter)
        {
            BreweryRepo brew = new BreweryRepo();

            ViewBag.Cities = ListOfCities();

            IEnumerable<Brewery> brewery;
            using (brew)
            {
                brewery = brew.SelectAll() as IList<Brewery>;
            }

            if (searchCriteria != null)
            {
                brewery = brewery.Where(b => b.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }
            return View(brewery);
        }
        [NonAction]

        private IEnumerable<string> ListOfCities()
        {
            BreweryRepo breweries = new BreweryRepo();

            IEnumerable<Brewery> brewerys;
            using (breweries)
            {
                brewerys = breweries.SelectAll() as IList<Brewery>;
            }

            var cities = brewerys.Select(b => b.City).Distinct().OrderBy(x => x);
            return cities;
        }

        // GET: Brewery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brewery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brewery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Brewery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Brewery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Brewery/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Brewery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
