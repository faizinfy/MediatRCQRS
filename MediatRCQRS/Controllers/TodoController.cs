﻿using Microsoft.AspNetCore.Http;
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
        return Ok(response);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetById(int id)
    {
      try
      {
        var response = await _mediator.Send(new GetTodoByIdQuery(id));
        return Ok(response);
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
        var response = await _mediator.Send(new AddToDoCommand { 
          Todo = todo        
        });
        return Ok(response);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, UpdateTodoCommand command)
    {
      try
      {
        command.Id = id;
        var response = await _mediator.Send(command);
        return Ok(response);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return Ok(await _mediator.Send(new DeleteTodoCommand { Id = id }));
    }

  }
}
