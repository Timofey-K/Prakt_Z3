using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Zadanie.Common;
using Zadanie_3.Models;

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
            return View(_rewardStorage.GetRewardsList().Select(x => x.ConvertToViewModelR()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RewardViewModel newReward)
        {
            _rewardStorage.AddReward(newReward.ConvertToDomainModelR());
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public IActionResult Edit(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardViewModel editedReward = _rewardStorage.GetRewardsList().FirstOrDefault(r => r.Id == rewardId.Value).ConvertToViewModelR();
            if (editedReward == null)
                return NotFound();
            return View(editedReward);
        }
        [HttpPost]
        public IActionResult Edit(RewardViewModel editedReward)
        {
            _rewardStorage.UpdateReward(editedReward.ConvertToDomainModelR());
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public IActionResult Delete(int? rewardId)
        {
            if (!rewardId.HasValue)
                return RedirectToAction(nameof(Index));
            RewardViewModel rewardRemove = _rewardStorage.GetRewardsList().FirstOrDefault(r => r.Id == rewardId.Value).ConvertToViewModelR();
            if (rewardRemove == null)
                return NotFound();
            return View(rewardRemove);
        }
        [HttpPost]
        public IActionResult Delete(int rewardId)
        {
            bool success = _rewardStorage.RemoveRewardById(rewardId);

            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
