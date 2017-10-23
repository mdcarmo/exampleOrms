using Core.Interfaces;
using Infrastructure.EF.EntityConfigurations;
using Model.Entities;
using Model.Interfaces;
using System.Data.Entity;

namespace Infrastructure.EF
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly Repository<User> _userRepository;
        private readonly Repository<Customer> _customerRepository;

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public UnitOfWork()
            : base("name=ExempleOrmsContext")
        {
            _userRepository = new Repository<User>(Users);
            _customerRepository = new Repository<Customer>(Customers);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public IRepository<User> UserRepository
        {
            get { return _userRepository; }
        }

        public IRepository<Customer> CustomerRepository
        {
            get { return _customerRepository; }
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
