using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie_3.Models;

namespace Zadanie_3.Services
{
    

    public class InMemoryStorage : IStorage
    {
        List<RewardViewModel> _RewardStorage = new List<RewardViewModel>
        {
            new RewardViewModel {Id=1, Title="За честность", Description="Не врал"},
            new RewardViewModel {Id=2, Title="За красоту", Description="Лучший наряд"}
        };
        List<UserViewModel> _UserStorage = new List<UserViewModel>
        {
           new UserViewModel {Id=1, Name="Ваня", Family="Петров", Date=DateTime.Now, Reward="За честность"},
           new UserViewModel {Id=2, Name="Соня", Family="Зубова", Date=DateTime.Now, Reward="За красоту"}
        };

        public int AddReward(RewardViewModel reward)
        {
            int index = _RewardStorage.Any() ? _RewardStorage.Max(m => m.Id) + 1 : 0;
            reward.Id = index;
            _RewardStorage.Add(reward);
            return index;
        }

        public int AddUser(UserViewModel user)
        {
            int index = _UserStorage.Any() ? _UserStorage.Max(m => m.Id) + 1 : 0;
            user.Id = index;
            _UserStorage.Add(user);
            return index;
        }

        public IEnumerable<UserViewModel> GetRewardsByUserId(int id)
        {
            List<UserViewModel> rewardsUser = new List<UserViewModel>();
            foreach (UserViewModel user in _UserStorage)
            {
                if (user.Id == id)
                {
                    rewardsUser.Add(user);
                }
            }
            return rewardsUser;
        }

        public IEnumerable<RewardViewModel> GetRewardsList()
        {
            return _RewardStorage;
        }

        public IEnumerable<UserViewModel> GetUsersList()
        {
            return _UserStorage;
        }

        public bool RemoveReward(int userId, int rewardId)
        {
            foreach (UserViewModel user in _UserStorage)
            {
                if (user.Id == userId)
                {
                    foreach (RewardViewModel reward in _RewardStorage)
                    {
                        if (reward.Id == rewardId)
                        {
                            if (user.Reward == reward.Title)
                            {
                                return _UserStorage.Remove(user);
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool RemoveRewardById(int id)
        {
            var note = _RewardStorage.FirstOrDefault(note => note.Id == id);
            return _RewardStorage.Remove(note);
        }

        public bool RemoveUserById(int id)
        {
            var note = _UserStorage.FirstOrDefault(note => note.Id == id);
            return _UserStorage.Remove(note);
        }

        public int RewardUser(int userId, int rewardId)
        {
            UserViewModel user = _UserStorage.FirstOrDefault(note => note.Id == userId);
            RewardViewModel reward = _RewardStorage.FirstOrDefault(note => note.Id == rewardId);
            user.Reward = reward.Title;
            int index = _UserStorage.Max(m => m.Id) + 1;
            user.Id = index;
            _UserStorage.Add(user);
            return index;
        }

        public int UpdateReward(RewardViewModel reward)
        {
            int index = reward.Id;
            if (RemoveRewardById(index))
            {
                AddReward(reward);
            }
            return reward.Id;
        }

        public int UpdateUser(UserViewModel user)
        {
            if (RemoveUserById(user.Id))
            {
                AddUser(user);
            }
            return user.Id;
        }
    }
}

