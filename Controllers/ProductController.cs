using app_web.Models;
using app_web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app_web.Controllers
{
    public class ProductController : Controller
    {

        public readonly ProductService _productService;

        public readonly UserService _userService;

        public ProductController(ProductService productService, UserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public ActionResult Index(int page = 1, int itemsPerPage = 10)
        {

            List<Product> Products = _productService.GetProductAll();

            int totalItems = Products.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            if (page < 1)
                page = 1;
            else if (page > totalPages)
                page = totalPages;

            int startIndex = (page - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, totalItems);

            List<Product> ProductsToShow = Products.Skip(startIndex).Take(endIndex - startIndex).ToList();

            ViewBag.Products = ProductsToShow;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.ItemsPerPage = itemsPerPage;

            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            List<User> users = _userService.GetUserAll();
            return Json(users);
        }

        [HttpGet]
        public JsonResult EditarGet(int id)
        {
            Product Product = _productService.GetaByid(id);
            return Json(Product);
        }

        [HttpPost]
        public JsonResult CriarPost(int userId, string name, double prince)
        {
            Product Product = new Product();

            Product.Name = name;

            Product.Prince = prince;

            Product.Active = true;

            Product.UserId = userId;

            _productService.CreateProduct(Product);

            return Json("Sucesso na criação");
        }

        [HttpPost]
        public JsonResult EditarPost(int id, string name, double prince)
        {
            Product Product = _productService.GetaByid(id);
            Product.Name = name;

            Product.Prince = prince;

            _productService.UpdateProduct(Product);

            return Json("Sucesso na criação");
        }


        [HttpPost]
        public JsonResult Excluir(int id)
        {
            _productService.DeleteById(id);
            return Json("Sucesso na deleção");
        }
    }
}
