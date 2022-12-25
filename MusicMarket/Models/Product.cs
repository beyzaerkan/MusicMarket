using System.ComponentModel.DataAnnotations;

namespace MusicMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
