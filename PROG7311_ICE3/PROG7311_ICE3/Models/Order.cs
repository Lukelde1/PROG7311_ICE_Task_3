namespace PROG7311_ICE3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal Total => Items.Sum(i => i.TotalPrice);
    }
}
