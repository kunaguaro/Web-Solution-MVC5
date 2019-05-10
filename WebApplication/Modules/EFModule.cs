using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppGen.Infrastructure;

namespace WebApplication.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(WebAppContext)).As(typeof(IContext)).InstancePerLifetimeScope();

        }

    }
}