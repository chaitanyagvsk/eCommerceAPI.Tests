using eCommerceAPI.BusinessLogic;
using eCommerceAPI.Domain;
using eCommerceAPI.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace eCommerceAPI.Tests
{
    public class Tests
    {
        [Test]
        public void UserInfoTest()
        {
            var myConfiguration = new Dictionary<string, string>
                {
                    {"MySettings:Username", "Venkata Gadi"},
                    {"MySettings:Token", "test"}
                };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            UserService userService = new UserService(configuration);

            var result = userService.GetUserInfo();

            Assert.AreEqual(result.Name, "Venkata Gadi");
        }

        [Test]
        public void RespositoryServiceTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Name = "ProductNameA", Price = 99.99M, Quantity = 0 },
                new Product { Name = "ProductNameB", Price = 101.99M, Quantity = 0 },
                new Product { Name = "ProductNameC", Price = 10.99M, Quantity = 0 },
                new Product { Name = "ProductNameD", Price = 5M, Quantity = 0 },
                new Product { Name = "ProductNameF", Price = 999999999999M, Quantity = 0 }
            };

            SortBL sortBl = new SortBL();
            var result = sortBl.SortProducts(products, null, SortOption.Descending);

            Assert.AreEqual(result[0].Name, "ProductNameF");
        }
    }
}