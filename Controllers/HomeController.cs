using EFPROJECT1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFPROJECT1.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View(_productRepository.Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productRepository.CreateProduct(product);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_productRepository.GetById(Id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
           _productRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}