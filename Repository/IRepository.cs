using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal interface IRepository<T>where T : IEntity
    {
        List<T> GetAll();
        T Create(T value);
        T Update(T value);
        T Delete(T value);
        T GetById(int id);
    }
}
