namespace ToDo.Models
{
    public class ToDoListModel
    {

        public int Id { get; set; }
        public bool PublicList { get; set; }
        public int UserID { get; set; }
        public string ListName { get; set; }

    }
}
