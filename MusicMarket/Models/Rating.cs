namespace MusicMarket.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        public Product Product { get; set; }

    }
}
