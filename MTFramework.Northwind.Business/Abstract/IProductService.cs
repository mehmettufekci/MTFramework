using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(Product product);
        void Delete(Product product);
        void TransactionalOperation(Product product1, Product product2);

    }
}