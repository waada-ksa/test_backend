using Microsoft.AspNetCore.Mvc;
using MediatR;
using backend.Application.Commands;
using backend.Application.Queries;
using backend.Application.DTOs;

namespace backend.API.Controllers;

/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all users from the system
    /// </summary>
    /// <returns>A collection of all users</returns>
    /// <response code="200">Returns the list of users</response>
    /// <response code="500">If there was an internal server error</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    /// <summary>
    /// Retrieves a specific user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <returns>The user with the specified ID</returns>
    /// <response code="200">Returns the requested user</response>
    /// <response code="404">If the user was not found</response>
    /// <response code="500">If there was an internal server error</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    /// <summary>
    /// Creates a new user in the system
    /// </summary>
    /// <param name="command">The user creation command containing user details</param>
    /// <returns>The newly created user</returns>
    /// <response code="201">Returns the newly created user</response>
    /// <response code="400">If the input data is invalid or email already exists</response>
    /// <response code="500">If there was an internal server error</response>
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserCommand command)
    {
        try
        {
            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
