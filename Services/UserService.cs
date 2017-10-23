using Core.Interfaces;
using Infrastructure.Dapper;
using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IService<User>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Read only paramter that makes use of dapper
        /// </summary>
        private readonly IReadRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IReadRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public User Get(int id)
        {
            return _userRepository.FindById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetNewUsers()
        {
            return _userRepository.GetNewUsers();
        }

        public User Create(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();

            return user;
        }

        public User Update(User instance)
        {
            throw new NotImplementedException();
        }
    }
}
