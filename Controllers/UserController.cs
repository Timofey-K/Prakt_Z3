using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_3.Models;
using Zadanie_3.Services;

namespace Zadanie_3.Controllers
{
    public class UserController:Controller
    {
        private IStorage _userStorage;
        public UserController(IStorage storage)
        {
            _userStorage = storage;
        }
        public IActionResult Index()
        {
            return View(_userStorage.GetUsersList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserModel newUser)
        {
            _userStorage.AddUser(newUser);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserModel editedUser = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value);
            if (editedUser == null)
                return NotFound();
            
            return View(editedUser);
        }
        [HttpPost]
        public IActionResult Edit(UserModel editedUser)
        {
            _userStorage.UpdateUser(editedUser);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserModel userRemove = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value);
            bool success = _userStorage.RemoveUserById(userRemove.Id);
            if (!success)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
