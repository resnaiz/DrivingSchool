using DrivingSchool.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchool.Interfaces
{
    public interface IDrivingSchoolDbContext
    {
        public DbSet<Student> Students { get; set; }
        public int SaveChanges();

        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
