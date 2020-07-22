using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie_3.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<RewardViewModel> Rewards { get; set; }

        public UserViewModel()
        {
            Rewards = new List<RewardViewModel>();
        }

    }
}
