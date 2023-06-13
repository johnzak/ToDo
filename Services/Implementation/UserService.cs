using Domain.Entities;
using Repo.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        public int CreateUser(User user)
        {
            return _IUserRepository.CreateUser(user);
        }

        public void DeleteUserById(int UserId)
        {
            _IUserRepository.DeleteUserById(UserId);
        }

        public void Edit(User user)
        {
            _IUserRepository.Edit(user);
        }

        public User GetUserById(int Id)
        {
            return _IUserRepository.GetUserById(Id);
        }

        public User GetUserByUserName(string Name)
        {
            return _IUserRepository.GetUserByUserName(Name);
        }
    }
}