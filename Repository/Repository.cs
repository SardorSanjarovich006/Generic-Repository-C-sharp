using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> items = new List<T>();

        public List<T> GetAll() => new List<T>(items);

        public T Create(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (items.Any(x => x.Id == value.Id))
                throw new InvalidOperationException($"Bu ID ({value.Id}) allaqachon mavjud!");

            items.Add(value);
            return value;
        }

        public T GetById(int id) => items.FirstOrDefault(x => x.Id == id);
        public T Update(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            int index = items.FindIndex(x => x.Id == value.Id);
            if (index == -1) return default;

            items[index] = value;
            return value;
        }

        public bool DeleteById(int id)
        {
            var obj = GetById(id);
            if (obj == null) return false;

            items.Remove(obj);
            return true;
        }
    }
}
