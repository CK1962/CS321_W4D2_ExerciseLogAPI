using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<string> GetAll()
        {
            var user = _userService.GetAll();
            var UserModel = Users.Select(u => u.ToApiModel());
            return Ok(UserModel);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            var UserModel = Users.Select(u => u.ToApiModel());
            if (user == null) return NotFound();
            return Ok(UserModel);
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
        public IActionResult Put(int id, [FromBody] UserModel updatedUser)
        {
            var user = _userService.Update(updatedUser.ToDomainModel());
            if (user == null) return NotFound();
            return Ok(UserService.ToApiModel());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Remove(User);
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