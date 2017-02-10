using ELMarion.Controllers;
using ELMarion.Data;
using ELMarion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ELMarionTest
{
    [TestClass]
    public class ProcessorTest
    {
        [TestMethod]
        public void TestFind()
        {
            //Arrange
            var data = new List<Product>
            {
                new Product {ProductID = 1, ProductName = "p1", ProductPrice = 1,ProductSKU =1 },
                new Product {ProductID = 2, ProductName = "p2", ProductPrice = 2,ProductSKU =2 },
                new Product {ProductID = 3, ProductName = "p3", ProductPrice = 3,ProductSKU =3 },
                new Product {ProductID = 4, ProductName = "p4", ProductPrice = 4,ProductSKU =4 }
            };

            var dbSetMock = new Mock<IDbSet<ProductContext>>();

            var controller = new ProductsController(dbSetMock.Object);

            //Action
            var result = controller.ProductsIndex() as ViewResult;
            var model = result.Model as FaqViewModel;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}