using System.ComponentModel.DataAnnotations;

namespace MusicMarket.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Product Product { get; set; }

    }
}
