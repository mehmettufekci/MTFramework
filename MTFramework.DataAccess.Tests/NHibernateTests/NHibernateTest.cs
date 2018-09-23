using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTFramework.Northwind.DataAccess.Concrete.NHibernate;
using MTFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace MTFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new OracleHelper());

            var result = productDal.GetList();

            Assert.AreEqual(77, result.Count);

        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new OracleHelper());

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);

        }
    }
}
