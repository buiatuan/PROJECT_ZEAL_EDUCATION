using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Models.Request.RegisterRequest;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    public class ScholarRegisterController : BaseController<ScholarRegisterController>
    {
        public ScholarRegisterController(ProjectSem3Context dbContext,
            ILogger<ScholarRegisterController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpPost]
        public IActionResult Create([FromBody] ScholarRegisterModel model)
        {
            var data = new Account
            {
                Username = model.Username,
                Password = model.Password,
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Address = model.Address,
                Descreption = model.Descreption,
                RoleId = 3,
                DateOfbirth = model.DateOfbirth
            };
            _dbContext.Accounts.Add(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok("Success") : BadRequest("Failed");
        }
    }
}
