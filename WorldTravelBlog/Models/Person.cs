using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WorldTravelBlog.Models
{
	[Table("People")]
	public class Person
	{
		[Key]
		public int PersonId { get; set; }
		public string Name { get; set; }
		public int LocationId { get; set; }
        public int ExperienceId { get; set; }
		public virtual Location Location { get; set; }
        public virtual Experience Experience { get; set; }
	}
}
