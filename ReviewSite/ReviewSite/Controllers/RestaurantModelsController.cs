using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewSite.Context;
using ReviewSite.Models;

namespace ReviewSite.Controllers
{
    public class RestaurantModelsController : Controller
    {
        private readonly RestaurantContext _context;

        public RestaurantModelsController(RestaurantContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Restaurants.ToList());
        }

        //Search Bar Method:
        public ActionResult ShowSearchForm()
        {
            return View();
        }
        //POST method for ShowSearchResults
        public ActionResult ShowSearchResults(string SearchPhrase)
        {
            return View("Index", _context.Restaurants.Where(r => r.Name.Contains(SearchPhrase)));
        }


        public ActionResult Details(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurantModel = _context.Restaurants
                .Where(i => i.Id == id)
                .Include(i => i.Reviews)
                .FirstOrDefault();
            if (restaurantModel == null)
            {
                return NotFound();
            }

            return View(restaurantModel);
        }

        [Authorize]

        public ActionResult Create()
        {
            RestaurantModel restaurant = new RestaurantModel();
            return View(restaurant);
        }

        [HttpPost]

        public ActionResult Create(RestaurantModel restaurantModel) //bind= keeping the three data strings together
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurantModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurantModel = _context.Restaurants.Find(id);
            if (restaurantModel == null)
            {
                return NotFound();
            }
            return View(restaurantModel);
        }

        [HttpPost]

        public ActionResult Edit(int id, RestaurantModel restaurantModel)
        {
            if (id != restaurantModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantModel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantModelExists(restaurantModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurantModel = _context.Restaurants
                .FirstOrDefault(m => m.Id == id);
            if (restaurantModel == null)
            {
                return NotFound();
            }

            return View(restaurantModel);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            if (_context.Restaurants == null)
            {
                return Problem("Entity set 'RestaurantContext.Restaurants'  is null.");
            }
            var restaurantModel = _context.Restaurants.Find(id);
            if (restaurantModel != null)
            {
                _context.Restaurants.Remove(restaurantModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool RestaurantModelExists(int id) //method for lambda equation below
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
