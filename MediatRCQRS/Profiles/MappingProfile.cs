using AutoMapper;
using MediatRCQRS.Queries;
using MediatRCQRS.Commands;
using MediatRCQRS.Models;
using MediatRCQRS.Dto;

namespace MediatRCQRS.Profiles
{
  public class MappingProfile : Profile
  {
    public void AutoMapperProfile()
    {
      CreateMap<Todo, GetAllTodoResponseDto>();
    }
  }
}
