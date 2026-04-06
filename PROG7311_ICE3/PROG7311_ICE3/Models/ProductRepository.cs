namespace PROG7311_ICE3.Models
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 18000 },
            new Product { Id = 2, Name = "Phone", Price = 9000 },
            new Product { Id = 3, Name = "Tablet", Price = 5500 }
        };

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
