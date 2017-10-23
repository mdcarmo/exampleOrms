using Core.Interfaces;
using Infrastructure.Dapper;
using Infrastructure.EF;
using Model.Entities;
using Model.Interfaces;
using Services;
using Unity;
using Unity.Lifetime;

namespace CrossCutting
{
    public static class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IService<User>, UserService>(new PerThreadLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new PerThreadLifetimeManager());
            container.RegisterType<IReadRepository<User>, UserRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IReadRepository<Customer>, CustomerRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerThreadLifetimeManager());
        }
    }
}
