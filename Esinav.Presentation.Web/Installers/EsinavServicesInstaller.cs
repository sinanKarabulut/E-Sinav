using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Esinav.Application.Location;
using Esinav.DataAccess.Context;
using Esinav.Domain.Location.Service;
using Esinav.Domain.Shared.DbContext;
using Esinav.Domain.Shared.Repository;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esinav.Presentation.Web.Installers
{
    public class EsinavServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
               .Register(Component.For<IDbContextForCRUD>()
                   .ImplementedBy<ApplicationDbContextForCRUD>()
                   .LifeStyle.PerWebRequest
               );

            // CRUD Repository
            container
                .Register(Component.For(typeof(IRepositoryForCRUD<>))
                    .ImplementedBy(typeof(RepositoryForCRUD<>))
                    .LifeStyle.PerWebRequest
                );

            // ApplicationUserManager
            container.Register(Component.For<ApplicationUserManager>()
                .UsingFactoryMethod(
                    (kernel, creationContext) => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                )
                .LifestylePerWebRequest());

            // ApplicationSignInManager
            container.Register(Component.For<ApplicationSignInManager>()
                .UsingFactoryMethod(
                    (kernel, creationContext) => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()
                )
                .LifestylePerWebRequest());


            container
               .Register(Component.For<IServiceCRUDSehir>()
                   .ImplementedBy<ServiceCRUDSehir>()
                   .LifeStyle.PerWebRequest
               );

            container
               .Register(Component.For<IServiceCRUDIlce>()
                   .ImplementedBy<ServiceCRUDIlce>()
                   .LifeStyle.PerWebRequest
               );




        }
    }
}