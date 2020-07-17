using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_3.Models;

namespace Zadanie_3.Controllers
{
    public class RewardController:Controller
    {
        private static List<RewardModel> _Rewards = new List<RewardModel>
        {
            new RewardModel {Id=1, Name="За честность", Description="Не врал"},
            new RewardModel {Id=2, Name="За красоту", Description="Лучший наряд"}
        };

        public RewardController()
        {

        }
        public IActionResult Index()
        {
            return View(_Rewards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RewardModel newReward)
        {
            newReward.Id = _Rewards.Max(m => m.Id) + 1;
            _Rewards.Add(newReward);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardModel editedReward = _Rewards.FirstOrDefault(u => u.Id == rewardId.Value);
            if (editedReward == null)
                return NotFound();
            _Rewards.Remove(editedReward);
            return View(editedReward);
        }
        [HttpPost]
        public IActionResult Edit(RewardModel editedReward)
        {
            editedReward.Id = _Rewards.Max(m => m.Id) + 1;
            _Rewards.Add(editedReward);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardModel rewardRemove = _Rewards.FirstOrDefault(u => u.Id == rewardId.Value);
            if (rewardRemove == null)
                return NotFound();
            _Rewards.Remove(rewardRemove);
            return RedirectToAction(nameof(Index));
        }
    
}
}
