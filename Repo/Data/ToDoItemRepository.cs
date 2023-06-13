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

        public class ToDoItemRepository : IToDoItemRepository
        {
            private readonly ApplicationDbContext _dbContext;

            public ToDoItemRepository(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        public void Check(int Id)
        {
            var item = GetToDoItemByItemId(Id);
            if (item != null)
            {
                item.Checked = true;
                _dbContext.SaveChanges();
            }
        }
        public int CreateToDoItem(ToDoItem ToDoItem)
        {
            var newToDoItem = _dbContext.ToDoItem.Add(ToDoItem);
            _dbContext.SaveChanges();
            return newToDoItem.Entity.Id;
        }

        public void DeleteToDoItem(int Id)
        {
            ToDoItem ToDoItem = GetToDoItemByItemId(Id);
            if (ToDoItem != null)
            {
                _dbContext.ToDoItem.Remove(ToDoItem);
                _dbContext.SaveChanges();
            }
        }

        public List<ToDoItem> GetAllToDoItemsByListId(int ListId)
        {

            return _dbContext.ToDoItem.Where(x => x.ToDoListID == ListId).ToList();
            
        }

        public ToDoItem? GetToDoItemByItemId(int Id)
        {
            return _dbContext.ToDoItem.Where(x => x.Id == Id).FirstOrDefault();
        }

        public ToDoItem? GetToDoItemByListId(int ListId)
        {
            return _dbContext.ToDoItem.Where(x => x.ToDoListID == ListId).FirstOrDefault();
        }

        public void UpdateToDoItem(ToDoItem ToDoItem)
        {
            var record = GetToDoItemByItemId(ToDoItem.Id);
            

            record.Data = ToDoItem.Data;
            record.Checked = ToDoItem.Checked;
            record.Priority = ToDoItem.Priority;
            record.DateCreated = ToDoItem.DateCreated;
            record.ToDoListID = ToDoItem.ToDoListID;

            _dbContext.ToDoItem.Update(record);
            _dbContext.SaveChanges();
        }
    }
}
