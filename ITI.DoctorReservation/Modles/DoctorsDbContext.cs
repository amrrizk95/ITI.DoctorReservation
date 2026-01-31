using Microsoft.EntityFrameworkCore;
using System;

namespace ITI.DoctorReservation.Modles
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext(DbContextOptions<DoctorsDbContext> options):base(options)
        {
            

        }
        public DbSet<Doctor> Doctors { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
      
    }
}
