using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoItem
    {
        public int Id { set; get; }
        public string Data { set; get; }
        public bool Checked { set; get; }
        public string Priority { set; get; }

        public string DateCreated { set; get; }
        public int ToDoListID { set; get; }



    }
 
}