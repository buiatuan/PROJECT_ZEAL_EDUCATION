using System;
using Common;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Models.Request;
using Models.Models.Response.CourseRegisterResponse;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Scholar
{
    public class RegisterCourseController : BaseController<RegisterCourseController>
    {
        public RegisterCourseController(ProjectSem3Context dbContext,
            ILogger<RegisterCourseController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpPost]
        public IActionResult ConfirmedCreate(ConfirmedRegisterCourse model)
        {
            var data = new ScholarCourse
            {
                Purchased = model.Purchased,
                TuitionFees = model.TuitionFees,
                ScholarId = model.ScholarId,
                CourseId = model.CourseId
            };
            _dbContext.ScholarCourses.Add(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }
    }
}

