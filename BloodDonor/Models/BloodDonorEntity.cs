using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BloodDonor.Models;

public class BloodDonorEntity
{
    public int Id { get; set; }
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
    [MaxLength]
    public string? ProfilePicture { get; set; }
    public DateTime? LastDonationDate { get; set; }
    public Collection<Donation> Donations { get; set;} =  new Collection<Donation>();
}

public enum BloodGroup
{
    APositive,
    ANegative,
    BPositive,
    BNegative,
    ABPositive,
    ABNegative,
    OPositive,
    ONegative
}

public class Donation
{
    public int Id { get; set; }
    public required DateTime DonationDate { get; set; }
    public required int BloodDonorId { get; set; }
}