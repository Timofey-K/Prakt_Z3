using System.Collections.Generic;
using Zadanie.Common.Models;

namespace Zadanie.Common
{
    public interface IStorage
    {
        int AddReward(RewardModel reward);
        int AddUser(UserModel user);
        bool RemoveRewardById(int id);
        bool RemoveUserById(int id);
        IEnumerable<RewardModel> GetRewardsList();
        IEnumerable<UserModel> GetUsersList();
        bool UpdateReward(RewardModel reward);
        bool UpdateUser(UserModel user);
        List<RewardModel> GetRewardsByUserId(int id);
        bool RewardUser(int userId, int rewardId);

        //bool RemoveReward(int userId, int rewardId);
    }

}
