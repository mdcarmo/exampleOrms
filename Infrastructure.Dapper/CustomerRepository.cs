using Core.Interfaces;
using Dapper;
using Model.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Dapper
{
    public class CustomerRepository : IReadRepository<Customer>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["ExempleOrmsContext"].ConnectionString);
            }
        }

        public Customer FindById(int id)
        {
            Customer customer = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                customer = cn.Query<Customer>("SELECT * FROM Customers WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> customers = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                customers = cn.Query<Customer>("SELECT * FROM Customers");
            }

            return customers;
        }
    }
}
