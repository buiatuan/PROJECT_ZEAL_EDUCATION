using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace BACKEND_ZEAL_EDUCATION.Controllers
{
    public class CourseController : BaseController<CourseController>
    {
        public CourseController(ProjectSem3Context dbContext,
            ILogger<CourseController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetListCourse()
        {
            var courseList = _dbContext.Courses;
            return Ok(courseList);
        }
    }
}
