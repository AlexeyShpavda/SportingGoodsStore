using Microsoft.AspNetCore.Mvc;
using SportingGoodsStore.WebApp.Models;

namespace SportingGoodsStore.WebApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
