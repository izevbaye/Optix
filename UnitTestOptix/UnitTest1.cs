using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Optix.Service.ServiceAPI;
using Optix.Database.DbContext;

namespace UnitTestOptix
{
    [TestClass]
    public class TestMoviesController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new Optix.Service.ServiceAPI.MoviesController(testProducts);

            var result = controller.GetAllProducts() as List<Optix.Database.DbContextTbl_Movies>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new MoviesController(GetTestProducts());

            var result = controller.GetProduct(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        private List<Tbl_Movies> GetTestProducts()
        {
            var testProducts = new List<Tbl_Movies>();
            testProducts.Add(new Tbl_Movies { Id = 1, Name = "Demo1", Price = 1 });
            testProducts.Add(new Tbl_Movies { Id = 2, Name = "Demo2", Price = 3.75M });
            //testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
            //testProducts.Add(new Product { Id = 4, Name = "Demo4", Price = 11.00M });

            return testProducts;
        }
    }
