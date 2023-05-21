using System;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
	public class AdminTeacherController : BaseController<AdminTeacherController>
    {
        public AdminTeacherController(ProjectSem3Context dbContext,
            ILogger<AdminTeacherController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpPut("id:int")]
        public IActionResult DeleteTeacherAccount([FromRoute] int id)
        {
            var data = _dbContext.Accounts.FirstOrDefault(m => m.Id == id);
            if (data == null)
                return NotFound(Message.NOT_FOUND_DATA);
            data.Status = 0;
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }
    }
}

