using Microsoft.AspNetCore.Mvc;
using SportingGoodsStore.WebApp.Models;

namespace SportingGoodsStore.WebApp.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());
    }
}