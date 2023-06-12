using DrivingSchool.Models;
using System.Collections.Generic;

namespace DrivingSchool.Interfaces
{
    public interface IEntityService<T>
    {
        public T GetById<T>(int id) where T : Entity;
        public List<T> GetAll<T>() where T : Entity;
        public void Add<T>(T entity) where T : Entity;
        public void Update<T>(T entity) where T : Entity;
        public void Delete<T>(int id) where T : Entity;
    }
}
