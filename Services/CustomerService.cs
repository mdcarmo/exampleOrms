using Core.Interfaces;
using Infrastructure.Dapper;
using Model.Entities;
using Model.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Read only paramter that makes use of entity framework
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Read only paramter that makes use of dapper
        /// </summary>
        private readonly IReadRepository<Customer> _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, IReadRepository<Customer> customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Create using EF Repositorie
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public Customer Create(Customer instance)
        {
            _unitOfWork.CustomerRepository.Add(instance);
            _unitOfWork.Save();

            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public Customer Update(Customer instance)
        {
            var customerBD = _customerRepository.FindById(instance.Id);

            customerBD.FirstName = instance.FirstName;
            customerBD.LastName = instance.LastName;

            _unitOfWork.CustomerRepository.Attach(instance);
            _unitOfWork.Save();

            return instance;
        }

        /// <summary>
        /// Get using Dapper
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            return _customerRepository.FindById(id);
        }

        /// <summary>
        /// GetAll using Dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomersByLastName(string lastName)
        {
            return _customerRepository.GetCustomersByLastName(lastName);
        }
    }
}
