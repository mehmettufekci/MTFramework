using MTFramework.Core.DataAccess;
using MTFramework.Northwind.Entities.ComplexTime;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}