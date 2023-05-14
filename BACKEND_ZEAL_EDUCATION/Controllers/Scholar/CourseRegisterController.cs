using System;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

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
        
    }
}

