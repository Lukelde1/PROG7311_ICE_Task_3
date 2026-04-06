namespace PROG7311_ICE3.Models
{
    public class OrderService
    {
        private readonly List<Order> _orders = new List<Order>();

        public void PlaceOrder(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders() => _orders;
    }
}
