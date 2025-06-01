using BloodDonor.Data;
using Microsoft.AspNetCore.Mvc;
using BloodDonor.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.Controllers;

public class BloodDonorController : Controller
{
    private readonly ILogger<BloodDonorController> _logger;
    private readonly BloodDonorDbContext _context;
    private readonly IWebHostEnvironment _env;

    public BloodDonorController(ILogger<BloodDonorController> logger, BloodDonorDbContext context, IWebHostEnvironment env)
    {
        _logger = logger;
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> Index(string bloodGroup, string address)
    {
        IQueryable<BloodDonorEntity> query = _context.BloodDonors;
        if (!string.IsNullOrEmpty(bloodGroup))
        {
            query = query.Where(d => d.BloodGroup.ToString() == bloodGroup);
        }

        if (!string.IsNullOrEmpty(address))
        {
            query = query.Where(d => d.Address != null && d.Address == address);
        }
        var donors = await query.ToListAsync();
        return View(donors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BloodDonorCreateViewModel bloodDonor)
    {
        if (!ModelState.IsValid)
        {
            return View(bloodDonor);
        }

        var donorEntity = new BloodDonorEntity
        {
            FullName = bloodDonor.FullName,
            Email = bloodDonor.Email,
            ContactNumber = bloodDonor.ContactNumber,
            DateOfBirth = bloodDonor.DateOfBirth.ToUniversalTime(),
            BloodGroup = bloodDonor.BloodGroup,
            Weight = bloodDonor.Weight,
            Address = bloodDonor.Address,
            LastDonationDate = bloodDonor.LastDonationDate?.ToUniversalTime()
        };

        if (bloodDonor.ProfilePicture != null && bloodDonor.ProfilePicture.Length > 0)
        {
            var fileName = $"{Guid.NewGuid()}.{Path.GetExtension(bloodDonor.ProfilePicture.FileName)}";
            var folderPath = Path.Combine(_env.WebRootPath, "images");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fullPath = Path.Combine(folderPath, fileName);
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await bloodDonor.ProfilePicture.CopyToAsync(stream);
            }
            donorEntity.ProfilePicture = Path.Combine("images", fileName);
        }

        _context.BloodDonors.Add(donorEntity);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> GetDonorList()
    {
        return Ok(await _context.BloodDonors.ToListAsync());
    }
}