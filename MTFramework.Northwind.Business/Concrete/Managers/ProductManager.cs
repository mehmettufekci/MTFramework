using MTFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MTFramework.Core.Aspects.Postsharp.CacheApects;
using MTFramework.Core.Aspects.Postsharp.LogAspects;
using MTFramework.Core.Aspects.Postsharp.PerformanceAspects;
using MTFramework.Core.Aspects.Postsharp.TransactionAspects;
using MTFramework.Core.Aspects.Postsharp.ValidationAspects;
using MTFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MTFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MTFramework.Core.DataAccess;
using MTFramework.Northwind.Business.Abstract;
using MTFramework.Northwind.Business.ValidationRules.FluentValidation;
using MTFramework.Northwind.DataAccess.Abstract;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        // IQueryableRepository kullanmak istersen bu şekilde tanımmlayıp dependency injection yapmak lazım
        //private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
           // _queryable = queryable;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin")]
        [LogAspect(typeof(DatabaseLogger))]  //---> Business AssemblyInfo.cs de yazılarak tüm manager loglanabilir
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}