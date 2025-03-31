using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AT2_CS_MVC.Models
{
    public class ApplicantDbContext: IdentityDbContext
    {
        public DbSet<Applicant> ApplicantsDB { get; set; }

        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) 
            : base(options)
        {

            Database.EnsureCreated();

        }
    }
}
