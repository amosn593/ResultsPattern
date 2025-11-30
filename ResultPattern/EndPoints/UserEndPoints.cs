using MediatR;
using ResultPattern.Application.Commands;
using ResultPattern.Domain.DTOs;

namespace ResultPattern.EndPoints;

public static class UserEndPoints
{
    public static void MapUserEndPoints(this WebApplication app)
    {
        app.MapPost("/users", async (UserCreationDto userCreationDto, IMediator mediator) =>
        {
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
