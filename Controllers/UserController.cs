using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Zadanie.Common;
using Zadanie_3.Models;


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
            return View(_userStorage.GetUsersList().Select(x=>x.ConvertToViewModelU()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserViewModel newUser)
        {
            _userStorage.AddUser(newUser.ConvertToDomainModelU());
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserViewModel editedUser = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value).ConvertToViewModelU();
            if (editedUser == null)
                return NotFound();
            
            return View(editedUser);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel editedUser)
        {
            _userStorage.UpdateUser(editedUser.ConvertToDomainModelU());
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction(nameof(Index));
            UserViewModel userRemove = _userStorage.GetUsersList().FirstOrDefault(u => u.Id == userId.Value).ConvertToViewModelU();
     
            if (userRemove == null)
                return NotFound();
            return View(userRemove);
        }
        [HttpPost]
        public IActionResult Delete(int userId)
        {
            bool success = _userStorage.RemoveUserById(userId);
            if (!success)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }        
    }
}
