using LMS_API.DataAccess;
using LMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IDataAccess library;
        private readonly IConfiguration configuration;
        public AuthenticateController(IDataAccess library, IConfiguration configuration = null)
        {
            this.library = library;
            this.configuration = configuration;
        }
        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            if (library.AuthenticateUser(email, password, out User? user))
            {
                if (user != null)
                {
                    var jwt = new Jwt(configuration["Jwt:Key"], configuration["Jwt:Duration"]);
                    var token = jwt.GenerateToken(user);
                    return Ok(token);
                }
            }
            return Ok("Invalid");
        }
    }
}
