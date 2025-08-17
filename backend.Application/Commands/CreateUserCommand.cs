using MediatR;
using backend.Application.DTOs;

namespace backend.Application.Commands;

public record CreateUserCommand : IRequest<UserDto>
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? PhoneNumber { get; init; }
}
