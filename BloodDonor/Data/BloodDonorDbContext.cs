using BloodDonor.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.Data;

public class BloodDonorDbContext : DbContext
{
    public BloodDonorDbContext(DbContextOptions<BloodDonorDbContext> options) : base(options)
    {
        
    }
    public DbSet<Models.BloodDonorEntity> BloodDonors { get; set; }
    public DbSet<Donation> Donations { get; set; }
}