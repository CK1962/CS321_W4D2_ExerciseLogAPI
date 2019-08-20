using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _DbContext;

        public ActivityRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public Activity Add(Activity Activity)
        {
            _DbContext.Activity.Add(Activity);
            _DbContext.SaveChanges();
            return Activity;
        }

        public Activity Get(int id)
        {
            return _DbContext.Activity 
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _DbContext.Activity
                .ToList();
        }

        public Activity Update(Activity updatedActivity)
        {
            // get the ToDo object in the current list with this id 
            var currentActivity = _DbContext.Activity.Find(updatedActivity.Id);

            // return null if todo to update isn't found
            if (currentActivity == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _DbContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            // update the todo and save
            _DbContext.Activity.Update(currentActivity);
            _DbContext.SaveChanges();
            return currentActivity;
        }

        public void Remove(Activity Activity)
        {
            _DbContext.Activity.Remove(Activity);
            _DbContext.SaveChanges();
        }
    }
}
