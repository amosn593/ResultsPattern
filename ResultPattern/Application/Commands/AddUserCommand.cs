using MediatR;
using ResultPattern.Domain.DTOs;
using ResultPattern.Domain.Results;

namespace ResultPattern.Application.Commands;

public record AddUserCommand(UserCreationDto userCreationDto, CancellationToken cancellationToken = default) : IRequest<Result<UserDto>> ;
