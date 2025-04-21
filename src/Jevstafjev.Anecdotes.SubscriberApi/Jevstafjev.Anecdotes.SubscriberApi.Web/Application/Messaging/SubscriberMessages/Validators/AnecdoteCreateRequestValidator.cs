using FluentValidation;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.Queries;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Application.Messaging.SubscriberMessages.Validators;

public class AnecdoteCreateRequestValidator : AbstractValidator<SubscriberCreateRequest>
{
    public AnecdoteCreateRequestValidator()
    {
        RuleFor(x => x.Model.Email).NotEmpty().EmailAddress().Length(2, 100);
    }
}
