using CharityMVC.Models;
using CharityMVC.Services;
using CharityMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CharityMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class OurCausesController : Controller
{
    private readonly OurCausesService _ourCausesService;
    public OurCausesController()
    {
        _ourCausesService = new OurCausesService();
    }
    public IActionResult Index()
    {
        List<OurCauses> ourCauses = _ourCausesService.GetAllOurcauses();
        return View(ourCauses);
    }
    [HttpGet]
    public IActionResult Info(int id) 
    {
        OurCauses ourCauses = _ourCausesService.GetOurCausesById(id);
        return View(ourCauses);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(OurcausesVM ourCauses) 
    {
        if (ModelState.IsValid)
        {
            return BadRequest("Modeline baxx");
        }
        _ourCausesService.CreateOurCauses(ourCauses);

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Update(int id) 
    {
        OurCauses ourCauses = _ourCausesService.GetOurCausesById(id);
        return View(ourCauses);
    }
    [HttpPost]
    public IActionResult Update(int id, OurCauses ourCauses) 
    {
        _ourCausesService.UpdateOurCause(id,ourCauses);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id) 
    {
        _ourCausesService.DeleteOurCauses(id);
        return RedirectToAction(nameof(Index));
    }

}
