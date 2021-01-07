using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TodoLists.Commands;
using Application.TodoLists.Queries;
using AutoMapper;
using Domain.TodoAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger = null;
        private readonly IMediator _mediator = null;
        private readonly IMapper _mapper = null;

        public TodoController(ILogger<TodoController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> Get([FromRoute] string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetTodoByIdQuery(id)));
                //return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<CreateTodoCommandResult>> Add([FromBody] CreateTodoCommand command)
        public async Task<IActionResult> Add(CreateTodoCommand command)
        {
            try
            {
                //return Ok(await _mediator.Send(command));
                var result = await _mediator.Send(command);
                return base.Created($"api/Todo/{result.Payload.Id}", result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateTodoCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return base.BadRequest(ModelState);
                }
                var result = await _mediator.Send<UpdateTodoCommandResult>(command);
                if (result != null)
                {
                    return base.Ok(result);
                }
                return base.NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    //return base.BadRequest($"{id} is empty!");
                    return base.BadRequest("Id is empty!");
                }
                var result = await _mediator.Send(new DeleteTodoCommand(id));

                return base.Ok("Successfully Deleted!");
            }
            catch (ArgumentException)
            {
                return base.NotFound($"Id {id} not found!");
            }
            //Sir code review of previous tasks is also remaining
        }

    }
}

