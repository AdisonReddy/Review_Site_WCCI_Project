using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewSite.Context;
using ReviewSite.Models;

namespace ReviewSite.Controllers
{
    public class ReviewModelsController : Controller
    {
        private readonly RestaurantContext _context;

        public ReviewModelsController(RestaurantContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Reviews.Include(r=> r.Restaurants).OrderBy(r=> r.RestaurantsId).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviewModel = _context.Reviews
                .Include(r=> r.Restaurants)
                .FirstOrDefault(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }
        [Authorize]
        public ActionResult CreateRestaurant(int id)
        {
            ReviewModel review = new ReviewModel();
            review.RestaurantsId = id;
            return View(review);
        }

        [Authorize]
        public ActionResult Create()
        {
            ReviewModel review = new ReviewModel();
            return View(review);
        }

        [HttpPost]
        public ActionResult CreateRestaurant(ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                reviewModel.RestaurantsId = reviewModel.Id;
                reviewModel.Id = 0;
                _context.Add(reviewModel);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "RestaurantModels");
        }


        [HttpPost]

        public ActionResult Create(ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                reviewModel.RestaurantsId = GetRestaurant(reviewModel.NewRestaurant);
                _context.Add(reviewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviewModel = _context.Reviews
                .Where(m => m.Id == id)
                .Include(m => m.Restaurants)
                .FirstOrDefault();
            reviewModel.NewRestaurant = reviewModel.Restaurant;

            if (reviewModel == null)
            {
                return NotFound();
            }
            return View(reviewModel);
        }

        [HttpPost]

        public ActionResult Edit(int id, ReviewModel reviewModel)
        {
            if (id != reviewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reviewModel.RestaurantsId = GetRestaurant(reviewModel.NewRestaurant);
                    _context.Update(reviewModel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewModelExists(reviewModel.Id))
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
            return View(reviewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviewModel = _context.Reviews
                .FirstOrDefault(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            if (_context.Reviews == null)
            {
                return Problem("Entity set 'RestaurantContext.Reviews'  is null.");
            }
            var reviewModel = _context.Reviews.Find(id);
            if (reviewModel != null)
            {
                _context.Reviews.Remove(reviewModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ReviewModelExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }

        private int GetRestaurant(string restaurant)
        {
            RestaurantModel? pub = null;
            pub = _context.Restaurants.Where(p => p.Name.ToLower() == restaurant.ToLower())
                .FirstOrDefault();
            if (pub == null)
            {
                pub = new RestaurantModel { Name = restaurant };
                _context.Add(pub);
                _context.SaveChanges(true);
            }
            return pub.Id;
        }
    }
}
