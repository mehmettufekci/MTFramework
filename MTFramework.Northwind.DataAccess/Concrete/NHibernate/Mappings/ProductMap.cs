using FluentNHibernate.Mapping;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"PRODUCTS");

            LazyLoad();

            //Id(x => x.ProductId).Column("PRODUCTID");
            Id(x => x.ProductId).Column("PRODUCTID").GeneratedBy.SequenceIdentity("PRODUCTS_SEQ");

            Map(x => x.CategoryId).Column("CATEGORYID");
            Map(x => x.ProductName).Column("PRODUCTNAME");
            Map(x => x.QuantityPerUnit).Column("QUANTITYPERUNIT");
            Map(x => x.UnitPrice).Column("UNITPRICE");

        }
    }
}
