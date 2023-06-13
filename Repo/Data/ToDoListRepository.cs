using Domain.Entities;
using Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace Repo.Data
{
    public class ToDoListRepository: IToDoListRepository
    {
        private ApplicationDbContext _dbContext;
        // WHY DIDN'T U TELL US HOW TO DO THIS HEHEHE
       // private IToDoItemRepository _ToDoItemRepository;

        public ToDoListRepository(ApplicationDbContext dbContext/*, IToDoItemRepository toDoItemRepository*/)
        {
         
            _dbContext = dbContext;
            //_ToDoItemRepository = toDoItemRepository;
        }
        public int CreateToDoList(ToDoList ToDoList)
        {
            var newToDoList = _dbContext.ToDoList.Add(ToDoList);
            _dbContext.SaveChanges();
            return newToDoList.Entity.Id;
        }

        public void DeleteToDoList(int Id)
        {

            ToDoList ToDoList = GetToDoListById(Id);
            if (ToDoList != null)
            {
                _dbContext.ToDoList.Remove(ToDoList);
                _dbContext.SaveChanges();
            }
        }

        public List<ToDoList> GetAllToDoLists()
        {
            return _dbContext.ToDoList.ToList();

        }

        public ToDoList GetToDoListById(int Id)
        {
            return _dbContext.ToDoList.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<ToDoList> GetToDoListByUserId(int id)
        {
            return _dbContext.ToDoList.Where(x => x.UserID == id).ToList();
        }
        
        public List<ToDoList> GetPublicToDoLists()
        {
            return _dbContext.ToDoList.Where(x => x.PublicList == true).ToList();
        }

        public string SetToDoListName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDoList(ToDoList toDoList)
        {

            
            var record = GetToDoListById(toDoList.Id);

            toDoList.ListName = record.ListName;
            toDoList.PublicList = record.PublicList;

            _dbContext.ToDoList.Update(record);
            _dbContext.SaveChanges();
        }
   
    }
}
