using Zadanie.Common.Models;
using Zadanie_3.Models;

namespace Zadanie_3
{
    public static class Converter
    {
        public static UserViewModel ConvertToViewModelU(this UserModel domainModel)
        {
            return new UserViewModel()
            {
                Id = domainModel.Id,
                FirstName = domainModel.FirstName,
                LastName = domainModel.LastName,
                Birthdate = domainModel.Birthdate,
                //Rewards = domainModel.Rewards
            };
        }

        public static UserModel ConvertToDomainModelU(this UserViewModel viewModel)
        {
            return new UserModel()
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Birthdate = viewModel.Birthdate,
                //Rewards = viewModel.Rewards
            };
        }

        public static RewardViewModel ConvertToViewModelR(this RewardModel domainModel)
        {
            return new RewardViewModel()
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                Description = domainModel.Description
            };
        }

        public static RewardModel ConvertToDomainModelR(this RewardViewModel viewModel)
        {
            return new RewardModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description
            };
        }
    }
}
