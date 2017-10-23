using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T> : IReadRepository<T> where T : class, IEntity
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Remove(T entity);

        void Attach(T entity);
    }
}
