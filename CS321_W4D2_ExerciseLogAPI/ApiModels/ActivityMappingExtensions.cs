using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Core.Models
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                // TODO: fill in property mappings
                Id = activity.Id,
                Date = activity.Date,
                Duration = activity.Duration,
                Distance = activity.Distance,

                // TODO: the ActivityType property should contain the name of the activity type
                ActivityTypeId = ActivityType.Id,
                ActivityType = ActivityType.Name,
                // TODO: the User property should contain the user's name
                UserId = User.UserId,
                User = User.Name,
                Notes = Activity.Notes,
       
                // TODO: Make User a string property that will contain the User's name (updating the mapping code)
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                Date = activityModel.Date,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                // TODO: fill in property mappings
                ActivityTypeId = ActivityTypeModel.Id,
                ActivityType = ActivityTypeModel.Name,

                // TODO: leave User and ActivityType null
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
            return activities.Select(u => u.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(u => u.ToDomainModel());
        }
    }
}
