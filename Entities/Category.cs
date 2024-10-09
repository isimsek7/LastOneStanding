using System;
using System.ComponentModel.DataAnnotations.Schema;
using LastOneStanding.Enums;
namespace LastOneStanding.Entities
{
	public class Category:BaseEntity
	{
		public Category()
		{
		}
		public Categories CategoryType { get; set; }

		public List<Competitors> competitors { get; set; }
		[NotMapped]
        public string CategoryTypeName => CategoryType.ToString();
    }
}

