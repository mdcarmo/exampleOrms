using Core.Interfaces;
using Model.Entities;
using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        IEnumerable<Customer> GetCustomersByLastName(string lastName);
    }
}
