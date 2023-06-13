using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interfaces
{
    public interface IToDoItemRepository
    {
        public List<ToDoItem> GetAllToDoItemsByListId(int ListId);
        public ToDoItem? GetToDoItemByItemId(int Id);
        public ToDoItem? GetToDoItemByListId(int ListId);
        public int CreateToDoItem(ToDoItem ToDoItem);
        public void UpdateToDoItem(ToDoItem ToDoItem);
        public void DeleteToDoItem(int Id);
        public void Check(int Id);
    }
}
