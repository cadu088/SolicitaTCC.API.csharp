using Microsoft.AspNetCore.Mvc;
using SolicitaTCC.API.csharp.Services;
namespace SolicitaTCC.API.csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            LoginService loginService = new LoginService();
            return loginService.Login().Rows[0][1].ToString();
        }
    }
}