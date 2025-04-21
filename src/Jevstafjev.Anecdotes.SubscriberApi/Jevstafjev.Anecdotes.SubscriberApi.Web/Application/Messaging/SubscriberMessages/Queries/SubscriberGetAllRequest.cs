using Arch.EntityFrameworkCore.UnitOfWork;
using Ardalis.Result;
using AutoMapper;
using Jevstafjev.Anecdotes.SubscriberApi.Domain;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.ViewModels;
using MediatR;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.Queries;

public record SubscriberGetAllRequest : IRequest<Result<List<SubscriberViewModel>>>;

public class SubscriberGetAllRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<SubscriberGetAllRequest, Result<List<SubscriberViewModel>>>
{
    public Task<Result<List<SubscriberViewModel>>> Handle(SubscriberGetAllRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Subscriber>();

        var entities = repository.GetAll();
        var mapped = mapper.Map<List<SubscriberViewModel>>(entities);

        return Task.FromResult(Result.Success(mapped));
    }
}
