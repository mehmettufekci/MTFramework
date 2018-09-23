using FluentValidation;
using MTFramework.Northwind.Business.ValidationRules.FluentValidation;
using MTFramework.Northwind.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
        }
    }
}