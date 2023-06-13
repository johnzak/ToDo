using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {

        public User GetUserById(int Id);
        public User GetUserByUserName(String Name);
        public int CreateUser(User user);
        public void DeleteUserById(int UserID);
        public void Edit(User user);


    }
}
