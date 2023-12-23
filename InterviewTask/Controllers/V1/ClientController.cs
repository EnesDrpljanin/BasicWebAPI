using Asp.Versioning;
using InterviewTask.Domain;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewTask.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("create")]
        public IActionResult CreateClient(ClientModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_clientService.CreateClient(model));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_clientService.GetAll());
        }

        [HttpPut("update")]
        public IActionResult UpdateClient(ClientModel model)
        {
            if (model.Id == 0)
            {
                return BadRequest("'Id' is required field");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_clientService.UpdateClient(model));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _clientService.DeleteClient(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]

        public IActionResult GetById(int id)
        {
            var entity = _clientService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}
