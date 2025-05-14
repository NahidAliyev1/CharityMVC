using CharityMVC.Models;
using CharityMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharityMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly OurCausesService _ourCausesService;
        public HomeController()
        {
            _ourCausesService = new OurCausesService();
        }
        public IActionResult Index()
        {
            List<OurCauses> ourCauses = _ourCausesService.GetAllOurcauses(); 
            return View(ourCauses);
        }
    }
}
