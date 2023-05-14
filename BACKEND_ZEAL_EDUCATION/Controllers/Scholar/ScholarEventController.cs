using System;
using Common;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Scholar
{
    public class ScholarEventController : BaseController<ScholarEventController>
    {
        public ScholarEventController(ProjectSem3Context dbContext,
            ILogger<ScholarEventController> logger,
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
        public IActionResult GetDetail(int id)
        {
            var result = _dbContext.Events.Find(id);
            if (result == null) return NotFound("No event matching!");
            return Ok(result);
        }
    }
}

