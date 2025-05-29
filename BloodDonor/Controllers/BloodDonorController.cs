using Microsoft.AspNetCore.Mvc;
using BloodDonor.Models;

namespace BloodDonor.Controllers;

public class BloodDonorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BloodDonorEntity bloodDonor)
    {
        Console.WriteLine(bloodDonor);
        return RedirectToAction("Index");
    }
}