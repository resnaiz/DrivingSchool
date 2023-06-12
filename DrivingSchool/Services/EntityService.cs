using System.Collections.Generic;
using System.Linq;
using DrivingSchool.Interfaces;
using DrivingSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchool.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected IDrivingSchoolDbContext _context;

        public EntityService(IDrivingSchoolDbContext context)
        {
            _context = context;
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public void Add<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete<T>(int id) where T : Entity
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity == null) return;
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}