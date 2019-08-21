using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CS321_W4D2_ExerciseLogAPI.Controllers
{

    [Route("api/[controller]")]
    public class ActivityTypesController : Controller
    {
        private  readonly IActivityTypeService _activityTypeService;
        public ActivityTypesController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activityType = _activityTypeService.Get(id);
            var activityTypeModel = activityType.Select(u => u.ToApiModel());
            if (activityType == null) return NotFound();
            return Ok(activityTypeModel);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]activityTypeModel newactivityType)
        {
            try
            {
                _activityTypeService.Add(newActivityType.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivityType", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newActivityType.Id }, newActivityType);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] activityTypeModel updatedactivityType)
        {
            var activityType = _activityTypeService.Update(updatedactivityType.ToDomainModel());
            if (activityType == null) return NotFound();
            return Ok(activityType.ToApiModel());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _activityTypeService.Remove(activityType);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("DeleteActivityType", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}