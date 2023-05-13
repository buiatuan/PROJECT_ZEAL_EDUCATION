using Common;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Models.Request;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    public class AdminEventController : BaseController<AdminEventController>
    {
        public AdminEventController(ProjectSem3Context dbContext,
            ILogger<AdminEventController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetListEvent()
        {
            var result = _dbContext.Events;
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult Detail([FromRoute] int id) 
        { 
            var result = _dbContext.Events.Find(id);
            if (result == null) return NotFound(Message.NOT_FOUND_EVENT);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EventCreateModel model)
        {
            var newEvent = new Event
            {
                Name = model.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = "System",
                Description = model.Description,
                Location = model.Location,
                StartDate = model.StartDate,
                Status = model.Status,
            };
            _dbContext.Events.Add(newEvent);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ?  Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] EventCreateModel model)
        {
            var data = _dbContext.Events.Find(id);
            if (data == null) return NotFound(Message.NOT_FOUND_EVENT);
            data.Name = model.Name;
            data.Description = model.Description;
            data.Location = model.Location;
            data.StartDate = model.StartDate;
            data.Status = model.Status;
            _dbContext.Events.Update(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var data = _dbContext.Events.Find(id);
            if (data == null) return NotFound(Message.NOT_FOUND_EVENT);
            _dbContext.Events.Remove(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }
    }
}
