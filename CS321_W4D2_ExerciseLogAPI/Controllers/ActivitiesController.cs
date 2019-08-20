using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivitiesController : Controller
    {
        private IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            var activity = _activityService.GetAll();
            var activityModel = activity.FindAll(u => u.ToApiModel());
            return Ok(activityModel);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activity = _activityService.Get(id);
            var activityModel = activity.FindAll(u => u.ToApiModel());
            if (activity == null) return NotFound();
            return Ok(activityModel);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]activityModel newactivity)
        {
            try
            {
                _activityService.Add(newactivity.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newactivity.Id }, newactivity);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] activityModel updatedactivity)
        {
            var activity = _activityService.Update(updatedactivity.ToDomainModel());
            if (activity == null) return NotFound();
            return Ok(activity.ToApiModel());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _activityService.Remove(activity);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("DeleteActivity", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}