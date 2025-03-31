using Microsoft.AspNetCore.Mvc;

namespace AT2_CS_MVC.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
