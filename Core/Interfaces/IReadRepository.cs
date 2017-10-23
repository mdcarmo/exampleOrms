using System.Collections.Generic;
using System.Data;

namespace Core.Interfaces
{
    public interface IReadRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T FindById(int id);

        IEnumerable<T> GetAll();
    }
}
