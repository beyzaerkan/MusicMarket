using System.ComponentModel.DataAnnotations;

namespace MusicMarket.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public String UserId { get; set; }
        public String OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public MusicMarketUser User { get; set; }
    }
}
