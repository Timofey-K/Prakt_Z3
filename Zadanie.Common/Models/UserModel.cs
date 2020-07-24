using System;
using System.Collections.Generic;

namespace Zadanie.Common.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<RewardModel> Rewards { get; set; }
        public UserModel()
        {
            Rewards = new List<RewardModel>();
        }
    }
}
