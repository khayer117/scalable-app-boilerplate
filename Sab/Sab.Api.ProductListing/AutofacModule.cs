﻿using Autofac;
using Microsoft.Extensions.Logging;

namespace Sab.ProductListing.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope();
        }
    }
}
