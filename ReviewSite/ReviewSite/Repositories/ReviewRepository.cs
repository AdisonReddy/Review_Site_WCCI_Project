using ReviewSite.Context;
using ReviewSite.Models;
using ReviewSite.Repositories.interfaces;

namespace ReviewSite.Repositories
{
    public class ReviewRepository : Repository<ReviewModel>, IReviewRepository
    {
        public ReviewRepository(RestaurantContext dbcontext)
            : base(dbcontext)
        {
        }
    }
}
