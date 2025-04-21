using Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Common;

public class CommonDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapRazorPages();
    }
}
