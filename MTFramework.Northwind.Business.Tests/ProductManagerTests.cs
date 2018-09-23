using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTFramework.Northwind.Business.Concrete.Managers;
using MTFramework.Northwind.DataAccess.Abstract;
using MTFramework.Northwind.Entities.Concrete;
using FluentValidation;

namespace MTFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());

        }
    }
}