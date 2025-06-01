using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BloodDonor.Models;

public class BloodDonorCreateViewModel
{
    [Required]
    [MaxLength(30)]
    public required string FullName { get; set; }
    [Phone]
    [MaxLength(15)]
    public required string ContactNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    [EmailAddress]
    [MaxLength(30)]
    public required string Email { get; set; }
    public required BloodGroup BloodGroup { get; set; }
    [Range(40, 200)]
    public float Weight { get; set; }
    [MaxLength(100)]
    public string? Address { get; set; }
    public IFormFile? ProfilePicture { get; set; }
    public DateTime? LastDonationDate { get; set; }
    public Collection<Donation> Donations { get; set;} =  new Collection<Donation>();
}