using InsuranceTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceTest.Models.DAL
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<InsuranceCover>().HasData(new InsuranceCover
            {
                Id = 1, 
                MaxFund = 500000000,
                MinFund = 5000,
                RatePrecentage = 0.0052f,
                Title="پوشش جراحی",
                Author = 1,
                LastChangeDate = DateTime.Now,
                LastChangeUser = 1,
                RegisterDate = DateTime.Now,
                RegisterUser = 1,
                Visable = true
            });
            builder.Entity<InsuranceCover>().HasData(new InsuranceCover
            {
                Id = 2,
                MaxFund = 400000000,
                MinFund = 4000,
                RatePrecentage = 0.0042f,
                Title = "پوشش دندانپزشکی",
                Author = 1,
                LastChangeDate = DateTime.Now,
                LastChangeUser = 1,
                RegisterDate = DateTime.Now,
                RegisterUser = 1,
                Visable = true
            });
            builder.Entity<InsuranceCover>().HasData(new InsuranceCover
            {
                Id=3,
                MaxFund = 200000000,
                MinFund = 2000,
                RatePrecentage = 0.005f,
                Title = "پوشش بستری",
                Author = 1,
                LastChangeDate = DateTime.Now,
                LastChangeUser = 1,
                RegisterDate = DateTime.Now,
                RegisterUser = 1,
                Visable = true
            });

            base.OnModelCreating(builder);
        }


        public DbSet<InsuranceCover> InsuranceCover { get; set; }
        public DbSet<CompensationRequest> CompensationRequest { get; set; }

    }
}
