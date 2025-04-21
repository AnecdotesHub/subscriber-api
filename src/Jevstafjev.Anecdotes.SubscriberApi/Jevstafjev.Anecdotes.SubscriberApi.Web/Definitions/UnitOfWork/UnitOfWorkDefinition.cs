using Arch.EntityFrameworkCore.UnitOfWork;
using Jevstafjev.Anecdotes.SubscriberApi.Infrastructure;
using Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.UnitOfWork;

public class UnitOfWorkDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddUnitOfWork<ApplicationDbContext>();
    }
}
