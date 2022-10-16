using ProductManager.Models;

namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DemoContext _context;
        public ProductService(DemoContext demoContext)
        {
            _context = demoContext;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productUpdate = _context.Products.FirstOrDefault(c => c.Id == product.Id);
            productUpdate.Name = product.Name;
            productUpdate.Price = product.Price;
            productUpdate.Quantity = product.Quantity;
            productUpdate.CategoryId = product.CategoryId;
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == id);
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
