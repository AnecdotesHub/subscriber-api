﻿using Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.SubscriberApi.Web.Definitions.Mapping;

public class AutoMapperDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program));
    }

    public override void ConfigureApplication(WebApplication app)
    {
        var mapper = app.Services.GetRequiredService<AutoMapper.IConfigurationProvider>();
        if (app.Environment.IsDevelopment())
        {
            mapper.AssertConfigurationIsValid();
        }
        else
        {
            mapper.CompileMappings();
        }
    }
}
