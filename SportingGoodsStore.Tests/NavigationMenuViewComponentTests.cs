﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportingGoodsStore.WebApp.Components;
using SportingGoodsStore.WebApp.Models;
using SportingGoodsStore.WebApp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportingGoodsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
            }).AsQueryable());
            var target = new NavigationMenuViewComponent(mock.Object);

            // Act = get the set of categories
            var results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            var categoryToSelect = "Apples";
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 4, Name = "P2", Category = "Oranges"},
            }).AsQueryable<Product>());

            var target = new NavigationMenuViewComponent(mock.Object);

            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext()
            };

            target.RouteData.Values["category"] = categoryToSelect;

            // Action
            var result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            // Assert
            Assert.Equal(categoryToSelect, result);
        }
    }
}
