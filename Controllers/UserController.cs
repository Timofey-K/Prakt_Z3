using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_3.Models;

namespace Zadanie_3.Controllers
{
    public class UserController:Controller
    {
        private static List<UserModel> _Users = new List<UserModel>
        {
            new UserModel {Id=1, Name="Ваня", Family="Петров", Date=DateTime.Now, Reward="За честность"},
            new UserModel {Id=2, Name="Соня", Family="Зубова", Date=DateTime.Now, Reward="За красоту"}
        };

        public UserController()
        {

        }
        public IActionResult Index()
        {
            return View(_Users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserModel newUser)
        {
            newUser.Id = _Users.Max(m => m.Id) + 1;
            _Users.Add(newUser);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserModel editedUser = _Users.FirstOrDefault(u => u.Id == userId.Value);
            if (editedUser == null)
                return NotFound();
            _Users.Remove(editedUser);
            return View(editedUser);
        }
        [HttpPost]
        public IActionResult Edit(UserModel editedUser)
        {
            editedUser.Id = _Users.Max(m => m.Id) + 1;
            _Users.Add(editedUser);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserModel userRemove = _Users.FirstOrDefault(u => u.Id == userId.Value);
            if (userRemove == null)
                return NotFound();
            _Users.Remove(userRemove);
            return RedirectToAction(nameof(Index));
        }
    }
}
