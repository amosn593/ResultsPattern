using FluentValidation;
using MediatR;
using ResultPattern.Application.Commands;
using ResultPattern.Domain.DTOs;
using ResultPattern.Domain.Models;

namespace ResultPattern.EndPoints;

public static class UserEndPoints
{
    public static void MapUserEndPoints(this WebApplication app)
    {
        app.MapPost("/users", async (UserCreationDto userCreationDto, IMediator mediator, IValidator<UserCreationDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(userCreationDto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Results.BadRequest(new { Errors = errors });
            }

            var result = await mediator.Send(new AddUserCommand(userCreationDto), default);

            if(result.IsSuccess is false)
            {
                return Results.Problem(detail: result.Error!.Message);
            }

            return Results.Ok(result.Data);
        });
        //app.MapGet("/users", async (IMediator mediator, CancellationToken cancellationToken) =>
        //{
        //    var query = new GetUsersQuery();
        //    var result = await mediator.Send(query, cancellationToken);
        //    return result.Match(
        //        users => Results.Ok(users),
        //        error => Results.Problem(error.Message)
        //    );
        //});
    }
}
