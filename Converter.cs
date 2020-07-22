using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_3.Models;

namespace Zadanie_3
{
    public static class Converter
    {
        public static UserViewModel ConvertToViewModel( this UserModel domainModel)
        {
            return new UserViewModel()
            {
                Id = domainModel.Id,
                FirstName = domainModel.FirstName,
                LastName = domainModel.LastName,
                Birthdate = domainModel.Birthdate,
                Rewards = domainModel.Rewards
            };
        }

        public static UserModel ConvertTodomainModel(this UserViewModel viewModel)
        {
            return new UserViewModel()
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Birthdate = viewModel.Birthdate,
                Rewards = viewModel.Rewards
            };
        }
    }
}
