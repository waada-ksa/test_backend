using MediatR;
using backend.Application.DTOs;

namespace backend.Application.Queries;

public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
}
