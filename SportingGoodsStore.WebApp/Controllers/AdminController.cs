using Microsoft.AspNetCore.Mvc;
using SportingGoodsStore.WebApp.Models.Interfaces;

namespace SportingGoodsStore.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

    }
}