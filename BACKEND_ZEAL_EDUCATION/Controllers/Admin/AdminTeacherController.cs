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
        public IActionResult DeleteTeacherAccount(int id)
        {
            var data = _dbContext.Accounts.Where(m => m.Id == id).First();
            if (data == null)
                return NotFound(Message.NOT_FOUND_DATA);
            data.Status = 0;
            _dbContext.SaveChanges();
            return Ok(Message.SUCCESS);
        }
    }
}

