using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        // create
        Activity Add(Activity activity);
        // read
        Activity Get(int id);
        // update
        Activity Update(Activity updatedActivity);
        // delete
        void Remove(Activity activity);
        // list
        IEnumerable<Activity> GetAll();
    }
}
