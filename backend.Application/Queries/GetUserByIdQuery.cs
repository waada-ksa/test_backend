using MediatR;
using backend.Application.DTOs;

namespace backend.Application.Queries;

public record GetUserByIdQuery : IRequest<UserDto?>
{
    public int Id { get; init; }
}
