using app_web.Models;
using app_web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app_web.Controllers
{
    public class UserController : Controller
    {
        public readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(int page = 1, int itemsPerPage = 10)
        {

            List<User> users = _userService.GetUserAll();

            int totalItems = users.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            if (page < 1)
                page = 1;
            else if (page > totalPages)
                page = totalPages;

            int startIndex = (page - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, totalItems);

            List<User> usersToShow = users.Skip(startIndex).Take(endIndex - startIndex).ToList();

            ViewBag.Users = usersToShow;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.ItemsPerPage = itemsPerPage;

            return View();
        }

        [HttpGet]
        public JsonResult EditarGet(int id)
        {
            User user = _userService.GetaByid(id);

            return Json(user);
        }

        [HttpPost]
        public JsonResult CriarPost(string email, string password)
        {
            User user = new User();

            user.Email = email;

            user.Password = password;

            _userService.CreateUser(user);

            return Json("Sucesso na criação");
        }

        [HttpPost]
        public JsonResult EditarPost(int id, string email, string password)
        {
            User user = _userService.GetaByid(id);

            user.Email = email;
            user.Password = password;

            _userService.UpdateUser(user);

            return Json("Sucesso na criação"); 
        }


        [HttpPost]
        public JsonResult Excluir(int id)
        {
            _userService.DeleteById(id);
            return Json("Sucesso na deleção");
        }
    }
}
