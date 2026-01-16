using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class Repository<T>:IRepository<T>where T : IEntity
    {
        private readonly List<T> items;
        public Repository()
        {
            this.items = new List<T>();
        }

        public T Create(T value)
        {
            this.items.Add(value);
            return value;
        }

        public T Delete(T value)
        {
            this.items.Remove(value);
            return value;
        }

        public List<T> GetAll()
        {
          return this.items;
        }

        public T GetById(int id)
        {
          var item=this.items.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public T Update(T value)
        {
            throw new NotImplementedException();
        }
    }
}
