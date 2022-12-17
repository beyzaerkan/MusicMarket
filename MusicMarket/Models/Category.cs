using System.ComponentModel.DataAnnotations;

namespace MusicMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Product Product { get; set; }
 
    }
}
