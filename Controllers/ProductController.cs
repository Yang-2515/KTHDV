using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }
        public IActionResult Create()
        {
            return View(_productService.GetCategories());
        }
        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return View("Index", _productService.GetProducts());
            }
            return View("Error");
        }
        public IActionResult Get(int id)
        {
            ViewBag.Product = _productService.GetProduct(id);
            return View("Update",_productService.GetCategories());
        }
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return View("Index", _productService.GetProducts());
            }
            return View("Error");
        }
        public IActionResult Delete(int id)
        {
            if(_productService.GetProduct(id) == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(id);
            return View("Index", _productService.GetProducts());
        }
    }
}
