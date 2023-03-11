using System.ComponentModel.DataAnnotations;

namespace ReviewSite.Models
{
    public class RestaurantModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }


        public string? ImageUrl { get; set; }

        public virtual IEnumerable<ReviewModel>? Reviews { get; set; }

    }
}
