using Jevstafjev.Anecdotes.SubscriberApi.Domain;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.Queries;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.ViewModels;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Endpoints;

public class SubscriberEndpoints : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapAnecdoteEndpoints();
    }
}

internal static class AnecdoteEndpointsExtensions
{
    public static void MapAnecdoteEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/subscribers/").WithTags(nameof(Subscriber));

        group.MapPost("create", async ([FromServices] IMediator mediator, [FromBody] SubscriberCreateViewModel model, HttpContext context) =>
            await mediator.Send(new SubscriberCreateRequest(model), context.RequestAborted))
            .Produces(200)
            .WithOpenApi();

        group.MapGet("get-all", async ([FromServices] IMediator mediator, HttpContext context) =>
            await mediator.Send(new SubscriberGetAllRequest(), context.RequestAborted))
            .RequireAuthorization(AppData.DefaultPolicyName)
            .RequireAuthorization(x => x.RequireRole(AppData.AdministratorRoleName))
            .Produces(200)
            .ProducesProblem(401)
            .WithOpenApi();
    }
}
