using Core.Interfaces;
using Dapper;
using Model.Entities;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Dapper
{
    public static class CustomerRepositoryExtensions
    {
        public static IEnumerable<Customer> GetCustomersByLastName(this IReadRepository<Customer> repository, string lastName)
        {
            IEnumerable<Customer> customers = null;

            using (IDbConnection cn = repository.Connection)
            {
                cn.Open();
                const string SprocName = "sp_Read_Customers";
                customers = cn.Query<Customer>(SprocName, new { lastName }, commandType: CommandType.StoredProcedure);
            }

            return customers;
        }
    }
}
