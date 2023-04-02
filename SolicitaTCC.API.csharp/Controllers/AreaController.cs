using Microsoft.AspNetCore.Mvc;
using SolicitaTCC.API.csharp.Services;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Controllers
{
    [ApiController]
    [Route("area")]
    public class AreaController : Controller
    {
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAreas()
        {
            try
            {
                AreaService areaService = new AreaService();
                var Results = areaService.GetAreas();
                return Ok(new { success = true, result = Results });
            }catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getPeople")]
        [HttpPost]
        public IActionResult GetAreasPeople(Login user)
        {
            try
            {
                AreaService areaService = new AreaService();
                var Results = areaService.GetAreasPeople(user);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateArea(CreateArea data)
        {
            try
            {
                AreaService areaService = new AreaService();
                areaService.CreateArea(data);
                return Ok(new { success = true});
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("createLink")]
        [HttpPost]
        public IActionResult CreateLinkArea(CreateLinkArea data)
        {
            try
            {
                AreaService areaService = new AreaService();
                var Results = areaService.CreateLinkArea(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

    }
}
