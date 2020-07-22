using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Zadanie_3.Models;
using Practice.Common;


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
            return View(_userStorage.GetUsersList().Select(x=>x.ConvertToViewModel));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserViewModel newUser)
        {
            _userStorage.AddUser(newUser.ConvertTodomainModel());
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserViewModel editedUser = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value);
            if (editedUser == null)
                return NotFound();
            
            return View(editedUser);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel editedUser)
        {
            _userStorage.UpdateUser(editedUser);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserViewModel userRemove = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value);
            bool success = _userStorage.RemoveUserById(userRemove.Id);
            if (!success)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int userId)
        {
            IEnumerable<UserViewModel> users = _userStorage.GetRewardsByUserId(userId);
            return View(users);
        }
    }
}
