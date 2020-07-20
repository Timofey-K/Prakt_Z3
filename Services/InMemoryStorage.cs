using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie_3.Models;

namespace Zadanie_3.Services
{
    public interface IStorage
    {
        int AddReward(RewardModel reward);
        int AddUser(UserModel user);
        bool RemoveRewardById(int id);
        bool RemoveUserById(int id);
        IEnumerable<RewardModel> GetRewardsList();
        IEnumerable<UserModel> GetUsersList();
        int UpdateReward(RewardModel reward);
        int UpdateUser(UserModel user);
        IEnumerable<UserModel> GetRewardsByUserId(int id);
        int RewardUser(int userId, int rewardId);
        bool RemoveReward(int userId, int rewardId);
    }

    public class InMemoryStorage : IStorage
    {
        List<RewardModel> _RewardStorage = new List<RewardModel>
        {
            new RewardModel {Id=1, Name="За честность", Description="Не врал"},
            new RewardModel {Id=2, Name="За красоту", Description="Лучший наряд"}
        };
        List<UserModel> _UserStorage = new List<UserModel>
        {
           new UserModel {Id=1, Name="Ваня", Family="Петров", Date=DateTime.Now, Reward="За честность"},
           new UserModel {Id=2, Name="Соня", Family="Зубова", Date=DateTime.Now, Reward="За красоту"}
        };

        public int AddReward(RewardModel reward)
        {
            int index = _RewardStorage.Any() ? _RewardStorage.Max(m => m.Id) + 1 : 0;
            reward.Id = index;
            _RewardStorage.Add(reward);
            return index;
        }

        public int AddUser(UserModel user)
        {
            int index = _UserStorage.Any() ? _UserStorage.Max(m => m.Id) + 1 : 0;
            user.Id = index;
            _UserStorage.Add(user);
            return index;
        }

        public IEnumerable<UserModel> GetRewardsByUserId(int id)
        {
            List<UserModel> rewardsUser = new List<UserModel>();
            foreach (UserModel user in _UserStorage)
            {
                if (user.Id == id)
                {
                    rewardsUser.Add(user);
                }
            }
            return rewardsUser;
        }

        public IEnumerable<RewardModel> GetRewardsList()
        {
            return _RewardStorage;
        }

        public IEnumerable<UserModel> GetUsersList()
        {
            return _UserStorage;
        }

        public bool RemoveReward(int userId, int rewardId)
        {
            foreach (UserModel user in _UserStorage)
            {
                if (user.Id == userId)
                {
                    foreach (RewardModel reward in _RewardStorage)
                    {
                        if (reward.Id == rewardId)
                        {
                            if (user.Reward == reward.Name)
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
            UserModel user = _UserStorage.FirstOrDefault(note => note.Id == userId);
            RewardModel reward = _RewardStorage.FirstOrDefault(note => note.Id == rewardId);
            user.Reward = reward.Name;
            int index = _UserStorage.Max(m => m.Id) + 1;
            user.Id = index;
            _UserStorage.Add(user);
            return index;
        }

        public int UpdateReward(RewardModel reward)
        {
            int index = reward.Id;
            if (RemoveRewardById(index))
            {
                AddReward(reward);
            }
            return reward.Id;
        }

        public int UpdateUser(UserModel user)
        {
            if (RemoveUserById(user.Id))
            {
                AddUser(user);
            }
            return user.Id;
        }
    }
}

