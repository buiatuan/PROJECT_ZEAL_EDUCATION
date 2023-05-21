
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    public class AdminFeedBackController : BaseController<AdminFeedBackController>
    {
        public AdminFeedBackController(ProjectSem3Context dbContext,
            ILogger<AdminFeedBackController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_dbContext.FeedBacks);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var data = _dbContext.FeedBacks.FirstOrDefault(m => m.Id == id);
            if (data == null) return NotFound(Message.NOT_FOUND_FEEDBACK);
            _dbContext.FeedBacks.Remove(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }
    }
}
