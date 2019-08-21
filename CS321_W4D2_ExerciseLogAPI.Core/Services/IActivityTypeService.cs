using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;


namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeService
    {
        ActivityType Add(ActivityType ActivityType);
        ActivityType Get(int id);
        IEnumerable<ActivityType> GetAll();
        void Remove(ActivityType ActivityType);
        ActivityType Update(ActivityType updatedActivityType);
    }
}