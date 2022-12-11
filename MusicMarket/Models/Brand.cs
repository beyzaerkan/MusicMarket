namespace MusicMarket.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product Product { get; set; }

    }
}
