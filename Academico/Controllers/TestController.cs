using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
