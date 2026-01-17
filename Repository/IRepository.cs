using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T Create(T value);
        T Update(T value);
        bool DeleteById(int id);
        T GetById(int id);
    }
}
