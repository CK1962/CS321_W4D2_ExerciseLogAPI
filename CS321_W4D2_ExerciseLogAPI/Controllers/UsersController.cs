using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userModel = users.Select(u => u.ToApiModel());
            return Ok(userModel);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            var userModel = user.ToApiModel();
            if (user == null) return NotFound();
            return Ok(userModel);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UserModel newUserModel)
        {
            try
            {
                _userService.Add(newUserModel.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newUserModel.Id }, newUserModel);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel updatedUserModel)
        {
            var user = updatedUserModel.ToDomainModel();
            var updatedUser = _userService.Update(user);
            if (user == null) return NotFound();
            return Ok(updatedUser.ToApiModel());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _userService.Get(id);
                _userService.Remove(user);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("DeleteUser", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}