using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using ELMarion.Models;
using ELMarion.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ELMarionTest
{
    [TestClass]
    public class TestProductController
    {
        //[TestMethod]
        //public void ReturnsProductsIndexView()
        //{
        //    ProductsController controllerUnderTest = new ProductsController(new ELMarion.Data.ProductContext());
        //    var result = controllerUnderTest.ProductsIndex() as ViewResult;
        //    Assert.AreEqual("ProductsIndex", result.ViewName);
        //}

        [TestMethod]
        public void ReturnsDetailsView()
        {
            HomeController controllerUnderTest = new HomeController();
            var result = controllerUnderTest.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}