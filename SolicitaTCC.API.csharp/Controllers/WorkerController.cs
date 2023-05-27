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

        [Route("cancelRequests")]
        [HttpPut]
        public IActionResult cancelRequest(cancelRequestsWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.CancelRequest(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("createProject")]
        [HttpPost]
        public IActionResult createProject(createProjectWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.CreateProject(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getProject")]
        [HttpPost]
        public IActionResult getProjects(getRequestsWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.ListProject(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("updateProjectSituation")]
        [HttpPut]
        public IActionResult updateProjectSituation(updtProjectWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.updateSituationProject(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getStageTask")]
        [HttpGet]
        public IActionResult getStageTask()
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.getStageTask();
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("createTask")]
        [HttpPost]
        public IActionResult CreateTask(createTask data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.createTask(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("getTask")]
        [HttpPost]
        public IActionResult getTask(getTaskWorker data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.getTask(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("concludedTask")]
        [HttpPut]
        public IActionResult concludedTask(concludedTask data)
        {
            try
            {
                WorkerAdivisor sendRequest = new WorkerAdivisor();
                var Results = sendRequest.concludedTask(data);
                return Ok(new { success = true, result = Results });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }
    }
}
