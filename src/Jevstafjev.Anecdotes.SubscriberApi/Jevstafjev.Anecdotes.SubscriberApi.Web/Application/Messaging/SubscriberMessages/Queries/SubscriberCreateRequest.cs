using Arch.EntityFrameworkCore.UnitOfWork;
using Ardalis.Result;
using AutoMapper;
using Jevstafjev.Anecdotes.SubscriberApi.Domain;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.ViewModels;
using MediatR;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.Queries;

public record SubscriberCreateRequest(SubscriberCreateViewModel Model) : IRequest<Result<SubscriberViewModel>>;

public class SubscriberCreateRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<SubscriberCreateRequest, Result<SubscriberViewModel>>
{
    public async Task<Result<SubscriberViewModel>> Handle(SubscriberCreateRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Subscriber>();

        var entity = mapper.Map<Subscriber>(request.Model);
        if (repository.GetAll().Select(x => x.Email).Contains(entity.Email))
        {
            return Result.Invalid(new ValidationError("This email is already in use."));
        }

        await repository.InsertAsync(entity);
        await unitOfWork.SaveChangesAsync();

        var mapped = mapper.Map<SubscriberViewModel>(entity);
        return Result<SubscriberViewModel>.Success(mapped);
    }
}
