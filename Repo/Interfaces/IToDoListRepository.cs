using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interfaces
{
    public interface IToDoListRepository
    {
        public List<ToDoList> GetAllToDoLists();
        public ToDoList GetToDoListById(int id);
        public List<ToDoList> GetToDoListByUserId(int id);
        public List<ToDoList> GetPublicToDoLists();
        public int CreateToDoList(ToDoList toDoList);
        public void UpdateToDoList(ToDoList toDoList);
        public void DeleteToDoList(int Id);
    }
}
