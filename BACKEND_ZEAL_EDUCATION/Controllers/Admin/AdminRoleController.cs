using Microsoft.AspNetCore.Mvc;
using Models.Entites;
using System.Data;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    public class AdminRoleController : BaseController<AdminRoleController>
    {
        public AdminRoleController(ProjectSem3Context dbContext,
            ILogger<AdminRoleController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _dbContext.Roles.Select(m
                => new Role
                {
                    Id= m.Id,
                    Name= m.Name,
                    Descreption= m.Descreption,
                });
            return Ok(res);
        }

    }
}
