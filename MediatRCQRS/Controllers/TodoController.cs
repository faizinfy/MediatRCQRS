using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatRCQRS.Models;
using MediatRCQRS.Commands;
using MediatRCQRS.Queries;
using MediatRCQRS.Dto;
using MediatR;
using AutoMapper;

namespace MediatRCQRS.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class TodoController : Controller
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TodoController(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllTodoResponseDto>>> GetAll()
    {
      try
      {
        var response = await _mediator.Send(new GetAllTodoQuery());
        //return Ok(response);
        return _mapper.Map<List<GetAllTodoResponseDto>>(response);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoRequestDto newtodo)
    {
      try
      {
        var todo = _mapper.Map<Todo>(newtodo);
        var response = await _mediator.Send(new AddToDoCommand
        {
          Todo = todo
        });

        return Ok(response);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}
