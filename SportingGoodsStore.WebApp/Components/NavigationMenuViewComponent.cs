using Microsoft.AspNetCore.Mvc;
using SportingGoodsStore.WebApp.Models.Interfaces;
using System.Linq;

namespace SportingGoodsStore.WebApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
