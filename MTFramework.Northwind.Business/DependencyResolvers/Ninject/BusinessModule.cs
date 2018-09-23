using MTFramework.Core.DataAccess;
using MTFramework.Core.DataAccess.NHibernate;
using MTFramework.Northwind.Business.Abstract;
using MTFramework.Northwind.Business.Concrete.Managers;
using MTFramework.Northwind.DataAccess.Abstract;
using MTFramework.Northwind.DataAccess.Concrete.EntityFramework;
using MTFramework.Northwind.DataAccess.Concrete.NHibernate;
using MTFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            //Birisi senden IProductDal isterse NhProductDal ver
            Bind<IProductDal>().To<NhProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<NhUserDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(NhQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<OracleHelper>();

        }
    }
}