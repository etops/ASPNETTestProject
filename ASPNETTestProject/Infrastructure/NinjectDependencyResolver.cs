using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ASPNETTestProject.Domain.Abstract;
using Moq;
using ASPNETTestProject.Domain.Entities;

namespace ASPNETTestProject.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            Mock<IPortfolioRepository> mock = new Mock<IPortfolioRepository>();
            mock.Setup(m => m.Portfolios).Returns(new List<Portfolio> {
                new Portfolio { Name = "A", Description="Portfolio A in USD" },
                new Portfolio { Name = "B", Description="Portfolio B in CHF" },
                new Portfolio { Name = "C", Description="Portfolio C in EUR" }
                });
            kernel.Bind<IPortfolioRepository>().ToConstant(mock.Object);
        }
    }    
}