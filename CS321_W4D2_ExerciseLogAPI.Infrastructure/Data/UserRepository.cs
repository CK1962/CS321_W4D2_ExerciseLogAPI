using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
         private readonly AppDbContext _DbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public User Add(User user)
        {
            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return _DbContext.Users
                .Include(u => u.Activities)
                //.Include(u => u.ActivityType)
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _DbContext.Users
                .Include(u => u.Activities)
                //.Include(u => u.ActivityType)
                .ToList();
        }

        public User Update(User updatedUser)
        {
            // get the ToDo object in the current list with this id 
            var currentUser = _DbContext.Users.Find(updatedUser.Id);

            // return null if todo to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _DbContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            // update the todo and save
            _DbContext.Users.Update(currentUser);
            _DbContext.SaveChanges();
            return currentUser;
        }

        public void Remove(User user)
        {
            _DbContext.Users.Remove(user);
            _DbContext.SaveChanges();
        }
    }
}