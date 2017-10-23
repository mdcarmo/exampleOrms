using Dapper;
using Infrastructure.Dapper;
using Infrastructure.EF;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DatabaseCreator
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating Database...");

            using (var context = new UnitOfWork())
            {
                var customer = context.Customers.FirstOrDefault();
            }

            Console.WriteLine("Created Database...");

            CustomerRepository repository = new CustomerRepository();

            using (IDbConnection cn = repository.Connection)
            {
                cn.Open();
                Console.WriteLine("Adding procs into the Database...");

                cn.Execute(BuildDropSproc("sp_Read_Customer"));
                cn.Execute(BuildSproc("sp_Read_Customer"));

                Console.WriteLine("Inserting data into the Database...");

                cn.Execute(BuildInsertCustomersSql("Joao", "Silva", "JoaoSilva@gmail.com"));
                cn.Execute(BuildInsertCustomersSql("Maria", "Silva", "MariaSilva@gmail.com"));
                cn.Execute(BuildInsertCustomersSql("Mario", "Armario", "MarioArmario@gmail.com"));
            }

            Console.WriteLine("Database successfully created and seeded.");
            Console.ReadLine();
        }

        private static string BuildDropSproc(string sprocName)
        {
            return
                string.Format(
                    "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'P', N'PC')) "
                    + "DROP PROCEDURE [dbo].[{0}]",
                    sprocName);
        }

        private static string BuildSproc(string name)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            using (var stream = thisAssembly.GetManifestResourceStream(string.Format("DatabaseCreator.scripts.{0}.sql", name)))
            {
                if (stream == null)
                {
                    throw new ApplicationException("Stream is null.");
                }
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private static string BuildInsertCustomersSql(string firstName, string lastName, string emailAddress)
        {
            return
                string.Format(
                    "INSERT INTO [dbo].[Customers] ([FirstName] ,[LastName] ,[IsActive] ,[EmailAddress]) VALUES ('{0}' ,'{1}' ,1 ,'{2}') SELECT CAST(SCOPE_IDENTITY() as int)",
                    firstName,
                    lastName,
                    emailAddress);
        }
    }
}
