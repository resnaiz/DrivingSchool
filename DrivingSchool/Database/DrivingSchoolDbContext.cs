using DrivingSchool.Interfaces;
using DrivingSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchool.Database
{
    public class DrivingSchoolDbContext : DbContext, IDrivingSchoolDbContext
    {
        public DrivingSchoolDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
