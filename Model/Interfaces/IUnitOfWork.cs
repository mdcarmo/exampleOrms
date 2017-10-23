using Core.Interfaces;
using Model.Entities;
using System;

namespace Model.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        void Save();
    }
}
