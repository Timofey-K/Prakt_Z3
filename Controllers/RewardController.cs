using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Zadanie_3.Models;
using Zadanie_3.Services;

namespace Zadanie_3.Controllers
{
    public class RewardController : Controller
    {    
        private IStorage _rewardStorage;
        public RewardController(IStorage storage)
        {
            _rewardStorage = storage;
        }
        public IActionResult Index()
        {
            return View(_rewardStorage.GetRewardsList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RewardViewModel newReward)
        {
            _rewardStorage.AddReward(newReward);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardViewModel editedReward = _rewardStorage.GetRewardsList().FirstOrDefault(r => r.Id == rewardId.Value);
            if (editedReward == null)
                return NotFound();            
            return View(editedReward);
        }
        [HttpPost]
        public IActionResult Edit(RewardViewModel editedReward)
        {
            _rewardStorage.UpdateReward(editedReward);            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardViewModel rewardRemove = _rewardStorage.GetRewardsList().FirstOrDefault(r => r.Id == rewardId.Value);
            bool success = _rewardStorage.RemoveRewardById(rewardRemove.Id);
            if (!success)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
         
    }
}
