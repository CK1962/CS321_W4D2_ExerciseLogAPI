using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _DbContext;

        public ActivityTypeRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public ActivityType Add(ActivityType ActivityType)
        {
            _DbContext.ActivityTypes.Add(ActivityType);
            _DbContext.SaveChanges();
            return ActivityType;
        }

        public ActivityType Get(int id)
        {
            return _DbContext.ActivityTypes
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _DbContext.ActivityTypes
                .ToList();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // get the ToDo object in the current list with this id 
            var currentActivityType = _DbContext.ActivityTypes.Find(updatedActivityType.Id);

            // return null if todo to update isn't found
            if (currentActivityType == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _DbContext.Entry(currentActivityType)
                .CurrentValues
                .SetValues(updatedActivityType);

            // update the todo and save
            _DbContext.ActivityTypes.Update(currentActivityType);
            _DbContext.SaveChanges();
            return currentActivityType;
        }

        public void Remove(ActivityType ActivityType)
        {
            _DbContext.ActivityTypes.Remove(ActivityType);
            _DbContext.SaveChanges();
        }
    }
}