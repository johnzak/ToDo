using Domain.Entities;
using Repo.Data;
using Repo.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ToDoItemService : IToDoItemService
    {

        private readonly IToDoItemRepository _ToDoItemRepository;

        public ToDoItemService(IToDoItemRepository ToDoItemRepository)
        {
            _ToDoItemRepository = ToDoItemRepository;
        }

        public void Check(int Id)
        {
            _ToDoItemRepository.Check(Id);
        }

        public int CreateToDoItem(ToDoItem ToDoItem)
        {
            return _ToDoItemRepository.CreateToDoItem(ToDoItem);
        }

        public void DeleteToDoItem(int Id)
        {
            _ToDoItemRepository.DeleteToDoItem(Id);
        }

        public List<ToDoItem> GetAllToDoItemsByListId(int ListId)
        {
            return _ToDoItemRepository.GetAllToDoItemsByListId(ListId);
        }

        public ToDoItem? GetToDoItemByItemId(int Id)
        {
            return _ToDoItemRepository.GetToDoItemByItemId(Id);
        }

        public ToDoItem? GetToDoItemByListId(int ListId)
        {
            return _ToDoItemRepository.GetToDoItemByListId(ListId);
        }

        public void UpdateToDoItem(ToDoItem ToDoItem)
        {
            _ToDoItemRepository.UpdateToDoItem(ToDoItem);
        }
    }
}
