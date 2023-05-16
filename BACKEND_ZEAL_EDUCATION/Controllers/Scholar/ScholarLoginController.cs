using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Models.Request.LoginRequest;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Scholar
{
	public class ScholarLoginController : BaseController<ScholarLoginController>
	{
        public ScholarLoginController(ProjectSem3Context dbContext,
            ILogger<ScholarLoginController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult MatchAccount(string username,string password)
        {
            if(username == null || password == null)
            {
                return NotFound("NULL VALUE");
            }
            else
            {
                var account = _dbContext.Accounts.Where(m
                    => (m.Username == username)
                    && (m.Password == password)
                    );
                if (account == null)
                    return NotFound("Please try again your username or your password one more time!");
                return Ok("The username and password have been matched!");
            }
        }
    }
}

