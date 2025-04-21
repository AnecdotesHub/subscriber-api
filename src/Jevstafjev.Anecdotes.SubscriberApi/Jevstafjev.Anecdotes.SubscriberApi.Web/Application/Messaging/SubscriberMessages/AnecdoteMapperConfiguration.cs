using AutoMapper;
using Jevstafjev.Anecdotes.SubscriberApi.Domain;
using System.Security.Claims;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.ViewModels;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages;

public class AnecdoteMapperConfiguration : Profile
{
    public AnecdoteMapperConfiguration()
    {
        CreateMap<Subscriber, SubscriberViewModel>();

        CreateMap<SubscriberCreateViewModel, Subscriber>()
            .ForMember(x => x.Id, o => o.Ignore());
    }
}
