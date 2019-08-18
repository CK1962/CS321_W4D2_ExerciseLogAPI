using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserRepository
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        User Add(User user);
        // read
        User Get(int id);
        // update
        User Update(User user);
        // delete
        void Remove(User user);
        // list
        IEnumerable<User> GetAll();
    }
}
