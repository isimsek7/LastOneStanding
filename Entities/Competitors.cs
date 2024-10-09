using System;
using System.ComponentModel.DataAnnotations.Schema;
using LastOneStanding.Enums;

namespace LastOneStanding.Entities
{
	public class Competitors:BaseEntity
	{
		public string  FirstName { get; set; }
		public string LastName { get; set; }
		public int CategoryId { get; set; }
		//public Categories Category { get; set; }
		//[NotMapped]
		//public string CategoryName => Category != null ? Category.CategoryTypeName : "No Category";

    }
}

