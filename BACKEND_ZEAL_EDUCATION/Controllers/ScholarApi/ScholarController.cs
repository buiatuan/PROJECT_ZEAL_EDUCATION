using BACKEND_ZEAL_EDUCATION.Controllers.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace BACKEND_ZEAL_EDUCATION.Controllers.ScholarApi
{
    public class ScholarController : BaseController<ScholarController>
    {
        public ScholarController(ProjectSem3Context dbContext,
            ILogger<ScholarController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

    }
}
