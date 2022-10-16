using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
        void CreateProduct(Product product);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
