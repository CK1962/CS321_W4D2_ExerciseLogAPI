using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
