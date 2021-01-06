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

    }
}

