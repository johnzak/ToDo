using Domain.Entities;

namespace ToDo.Models
{
    public class ViewList1
    {
        public int ListId { get; set; }
        public List<ToDoItem> toDoItems { get; set; }
    }
}
