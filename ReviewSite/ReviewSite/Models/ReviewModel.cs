using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewSite.Models
{
    public class ReviewModel
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Your Name")]
        public string ReviewerName { get; set; }

        [Required]
        [Display(Name = "Review")]
        public string? ReviewText { get; set; }
        [Display(Name = "Month Visited")]
        public string? MonthVisited { get; set; }
        [Display(Name = "Year Visited")]
        public int? YearVisited { get; set; }

        public virtual RestaurantModel? Restaurants { get; set; }

        [ForeignKey("RestaurantModel")]

        public int RestaurantsId { get; set; }
        

        [NotMapped]
        [Display(Name = "Restaurant")]
        public string Restaurant
        {
            get
            {
                if (Restaurants is not null)
                {
                    return Restaurants.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        [NotMapped]
        [Display(Name = "Restaurant")]
        public string? NewRestaurant { get; set; }
    }
}
