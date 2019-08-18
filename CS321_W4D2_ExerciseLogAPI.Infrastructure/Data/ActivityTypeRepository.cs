using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _DbContext;

        public ActivityTypeRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public ActivityTypeRepository Add(ActivityTypeRepository ActivityType)
        {
            _DbContext.ActivityTypeRepository.Add(ActivityType);
            _DbContext.SaveChanges();
            return ActivityType;
        }

        public ActivityTypeRepository Get(int id)
        {
            return _DbContext.ActivityTypeRepository
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<ActivityTypeRepository> GetAll()
        {
            return _DbContext.ActivityTypeRepository
                .ToList();
        }

        public ActivityTypeRepository Update(ActivityTypeRepository updatedActivityType)
        {
            // get the ToDo object in the current list with this id 
            var currentUser = _DbContext.ActivityTypeRepository.Find(updatedActivityType.Id);

            // return null if todo to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _DbContext.Entry(currentActivityType)
                .CurrentValues
                .SetValues(updatedActivityType);

            // update the todo and save
            _DbContext.ActivityTypeRepository.Update(currentActivityType);
            _DbContext.SaveChanges();
            return currentActivityType;
        }

        public void Remove(ActivityTypeRepository ActivityType)
        {
            _DbContext.ActivityTypeRepository.Remove(Activity);
            _DbContext.SaveChanges();
        }
    }
}

