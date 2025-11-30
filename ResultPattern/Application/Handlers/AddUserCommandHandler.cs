using MediatR;
using ResultPattern.Application.Commands;
using ResultPattern.Domain.DTOs;
using ResultPattern.Domain.Interfaces;
using ResultPattern.Domain.Results;

namespace ResultPattern.Application.Handlers;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<UserDto>>
{
    private readonly ILogger<AddUserCommandHandler> _logger;
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(ILogger<AddUserCommandHandler> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    
    Task<Result<UserDto>> IRequestHandler<AddUserCommand, Result<UserDto>>.Handle(AddUserCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
