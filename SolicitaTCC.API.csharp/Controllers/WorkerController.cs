using Microsoft.AspNetCore.Mvc;
using SolicitaTCC.API.csharp.Services;
using SolicitaTCC.API.csharp.Models;
//using System.Web.Http;
using Microsoft.AspNetCore.Cors;

namespace SolicitaTCC.API.csharp.Controllers
{
    [ApiController]
    [Route("worker")]
    //[EnableCors(origins: "http://example.com", headers: "*", methods: "*")]
    
    //[DisableCors]
    public class WorkerController : Controller
    {
        [Route("getAdvisor")]
        [HttpPost]
        public IActionResult getAdvisor(getWorker data)
        {
            try
            {
                WorkerAdivisor getService = new WorkerAdivisor();
                var Results = getService.getAdvisor(data);
                return Ok(new { success = true, result = Results });
            }catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("sendRequest")]
        [HttpPost]
        public IActionResult sendRequest(postRequestWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.sendRequest(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getRequests")]
        [HttpPost]
        public IActionResult sendRequest(getRequestsWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.ListRequest(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }
    }
}
