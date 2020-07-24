using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie.Common;
using Zadanie.Common.Models;

namespace Zadanie.MemoryStorage
{
    public class InMemoryStorage : IStorage
    {
        private static List<RewardModel> rewards = new List<RewardModel>
        {
            new RewardModel {Id=1, Title="За честность", Description="Не врал"},
            new RewardModel {Id=2, Title="За красоту", Description="Лучший наряд"}
        };
        private static List<UserModel> users = new List<UserModel>
        {
           new UserModel {Id=1, FirstName="Ваня", LastName="Петров", Birthdate=new DateTime(2000, 10, 10), Rewards= new List<RewardModel>{rewards[0] } },
           new UserModel {Id=2, FirstName="Соня", LastName="Зубова", Birthdate=new DateTime(2001, 11, 11), Rewards= new List<RewardModel>{rewards[1] } }
        };

        public int AddReward(RewardModel reward)
        {
            int index = rewards.Any() ? rewards.Max(m => m.Id) + 1 : 0;
            reward.Id = index;
            rewards.Add(reward);
            return index;
        }

        public int AddUser(UserModel user)
        {
            int index = users.Any() ? users.Max(m => m.Id) + 1 : 0;
            user.Id = index;
            users.Add(user);
            return index;
        }

        public List<RewardModel> GetRewardsByUserId(int userId)
        {
            var userRewards = users.FirstOrDefault(u => u.Id == userId);
            if (users is null)
                return null;
            return userRewards.Rewards;
        }

        public IEnumerable<RewardModel> GetRewardsList()
        {
            return rewards;
        }

        public IEnumerable<UserModel> GetUsersList()
        {
            return users;
        }

        //public bool RemoveReward(int userId, int rewardId)
        //{
        //    foreach (UserModel user in users)
        //    {
        //        if (user.Id == userId)
        //        {
        //            foreach (RewardModel reward in rewards)
        //            {
        //                if (reward.Id == rewardId)
        //                {
        //                    if (user.Reward == reward.Title)
        //                    {
        //                        return users.Remove(user);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        public bool RemoveRewardById(int id)
        {
            RewardModel reward = rewards.FirstOrDefault(r => r.Id == id);
            return rewards.Remove(reward);
        }

        public bool RemoveUserById(int id)
        {
            UserModel user = users.FirstOrDefault(u => u.Id == id);
            return users.Remove(user);
        }

        public bool RewardUser(int userId, int rewardId)
        {
            UserModel user = users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return false;
            RewardModel reward = rewards.FirstOrDefault(r => r.Id == rewardId);
            if (reward != null)
            {
                user.Rewards.Add(reward);
                return true;
            }            
            return false;            
        }

        public bool UpdateReward(RewardModel reward)
        {
            RewardModel editedReward = rewards.FirstOrDefault(er => er.Id == reward.Id);
            if (editedReward is null)
            {
                return false;                
            }
            else
            {
                editedReward.Title = reward.Title;
                editedReward.Description = reward.Description;
                return true;
            }           
        }

        public bool UpdateUser(UserModel user)
        {
            UserModel editedUser = users.FirstOrDefault(eu => eu.Id == user.Id);
            if (editedUser is null)
            {
                return false;
            }
            else
            {
                editedUser.FirstName = user.FirstName;
                editedUser.LastName = user.LastName;
                editedUser.Birthdate = user.Birthdate;
                return true;
            }
        }
    }
}
