﻿using Microsoft.AspNetCore.Mvc;
using SportingGoodsStore.WebApp.Models;
using SportingGoodsStore.WebApp.Models.Interfaces;
using System.Linq;

namespace SportingGoodsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
        {
             Products = _productRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = productPage,
                 ItemsPerPage = PageSize,
                 TotalItems = category == null ?
                     _productRepository.Products.Count() :
                     _productRepository.Products.Where(e => e.Category == category).Count()
             },
             CurrentCategory = category
        });
    }
}