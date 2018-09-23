using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MTFramework.Core.DataAccess.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class OracleHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {

            return Fluently.Configure().Database(OracleClientConfiguration.Oracle10
                    .ConnectionString(c => c.FromConnectionStringWithKey("OracleNorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
