using Core.Interfaces;
using Dapper;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Dapper
{
    public static class UserRepositoryExtension
    {
        public static IEnumerable<User> GetNewUsers(this IReadRepository<User> repository)
        {
            IEnumerable<User> users = null;

            using (IDbConnection cn = repository.Connection)
            {
                cn.Open();
                users = cn.Query<User>("SELECT * FROM Users Where CreatedDate = @CreatedDate", new { CreatedDate = DateTime.Now });
            }

            return users;
        }
    }
}
