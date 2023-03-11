using ReviewSite.Context;
using ReviewSite.Models;
using ReviewSite.Repositories.interfaces;

namespace ReviewSite.Repositories
{
    public class RestaurantRepository : Repository<RestaurantModel>, IRestaurantRepository
    {
        public RestaurantRepository(RestaurantContext dbcontext)
            : base(dbcontext)
        {
        }
    }
}
