using Domain.Entities;
using Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Data
{
    
    public class UserRepository : IUserRepository
    {

        private ApplicationDbContext _dbContex;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContex = dbContext;
        }


        public int CreateUser(User user)
        {
            var newCustomer = _dbContex.User.Add(user);
            _dbContex.SaveChanges();
            return newCustomer.Entity.Id;
        }

        public void DeleteUserById(int UserID)
        {
            User user = GetUserById(UserID);
            if (user != null)
            {
                _dbContex.User.Remove(user);
                _dbContex.SaveChanges();
            }
        }

        public void Edit(User user)
        {
            _dbContex.User.Update(user);
            _dbContex.SaveChanges();
        }

        public User GetUserById(int Id)
        {
            return _dbContex.User.Where(x => x.Id == Id).FirstOrDefault();
        }

        
        public User GetUserByUserName(string UserName)
        {
            return _dbContex.User.FirstOrDefault(x => x.UserName == UserName);
  //        return _dbContex.Customers.Where(x => x.Name == name).FirstOrDefault();

        }
    }
}
