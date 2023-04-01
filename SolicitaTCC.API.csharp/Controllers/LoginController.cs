using Microsoft.AspNetCore.Mvc;
using SolicitaTCC.API.csharp.Services;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller
    {
        [Route("post")]
        [HttpPost]
        public IActionResult Login(userLogin userLogin)
        {
            try
            {
                LoginService loginService = new LoginService();
                var Results = loginService.Login(userLogin);
                return Ok(new { success = true, result = Results });
            }catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("create")]
        [HttpPost]
        public IActionResult LoginCreate(CreateLogin user)
        {
            try
            {
                LoginService loginService = new LoginService();
                var Results = loginService.LoginCreate(user);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getPeople")]
        [HttpPost]
        public IActionResult GetPeople(Login user)
        {
            try
            {
                LoginService loginService = new LoginService();
                var Results = loginService.GetPeople(user);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }
    }
}
