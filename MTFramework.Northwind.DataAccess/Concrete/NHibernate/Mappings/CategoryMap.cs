using FluentNHibernate.Mapping;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"CATEGORIES");

            LazyLoad();

            Id(x => x.CategoryId).Column("CATEGORYID");

            Map(x => x.CategoryName).Column("CATEGORYNAME");


        }
    }
}