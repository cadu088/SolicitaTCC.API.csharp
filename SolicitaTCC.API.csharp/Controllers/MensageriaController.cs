using Microsoft.AspNetCore.Mvc;
using SolicitaTCC.API.csharp.Services;
using SolicitaTCC.API.csharp.Models;
//using System.Web.Http;
using Microsoft.AspNetCore.Cors;

namespace SolicitaTCC.API.csharp.Controllers
{
    [ApiController]
    [Route("mensageria")]
    //[EnableCors(origins: "http://example.com", headers: "*", methods: "*")]
    
    //[DisableCors]
    public class MensageriaController : Controller
    {
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAreas(SendMensagem mensagem)
        {
            try
            {
                MesageriaService msgService = new MesageriaService();
                var Results = msgService.SendMsg(mensagem);
                return Ok(new { success = true, result = Results });
            }catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("sendMesagem")]
        [HttpPost]
        public IActionResult GetAreasPeople(ChatPeople chat)
        {
            try
            {
                MesageriaService areaService = new MesageriaService();
                var Results = areaService.getChat(chat);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }
    }
}
