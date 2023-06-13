using Domain.Entities;
using Repo.Data;
using Repo.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ToDoListService : IToDoListService
    {

        private  IToDoListRepository _ToDoListRepository;

        public ToDoListService(IToDoListRepository ToDoListRepository)
        {
            _ToDoListRepository = ToDoListRepository;
        }


        public int CreateToDoList(ToDoList toDoList)
        {
            return _ToDoListRepository.CreateToDoList(toDoList);
        }

        public List<ToDoList> GetPublicToDoLists()
        {
            return _ToDoListRepository.GetPublicToDoLists();
        }

        public void DeleteToDoList(int Id)
        {
            _ToDoListRepository.DeleteToDoList(Id);
        }

        public List<ToDoList> GetAllToDoLists()
        {
            return _ToDoListRepository.GetAllToDoLists();
        }

        public ToDoList GetToDoListById(int id)
        {
            return _ToDoListRepository.GetToDoListById(id);
        }

        public List<ToDoList> GetToDoListByUserId(int id)
        {
            return _ToDoListRepository.GetToDoListByUserId(id);
        }

        public void UpdateToDoList(ToDoList toDoList)
        {
            _ToDoListRepository.UpdateToDoList(toDoList);
        }
    }
}