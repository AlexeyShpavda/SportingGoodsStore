using Microsoft.AspNetCore.Mvc;

namespace SportingGoodsStore.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}