using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IService<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        T Create(T instance);

        T Update(T instance);
    }
}
