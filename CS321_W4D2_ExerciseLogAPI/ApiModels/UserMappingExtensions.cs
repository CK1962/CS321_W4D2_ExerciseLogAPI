using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User User)
        {
            return new UserModel
            {
                Id = User.Id,
                Name = User.Name,

            };
        }

        public static User ToDomainModel(this UserModel UserModel)
        {
            return new User
            {
                Id = UserModel.Id,
                Name = UserModel.Name,
                // TODO: fill in property mappings
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(u => u.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> UserModels)
        {
            return UserModels.Select(u => u.ToDomainModel());
        }
    }
}
