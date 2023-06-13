using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Entities
{

    public class User
    {
		//[Key]
		public int Id { get; set; }      /*qaaaaaaassssssssssssssssssssssssssssssssssssssssssssssssssssssssssw]\wwp7nnb*/   //By Tuna
		public String UserName { get; set; }
		public String Pass { get; set; }
		public String Name { get; set; }

    }
}


	//• User:
	//	○ UserName
	//	○ Pass
	//	○ UserID
	//	○ Name