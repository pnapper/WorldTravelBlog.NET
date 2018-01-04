using Microsoft.EntityFrameworkCore;

namespace WorldTravelBlog.Models
{
	public class WorldTravelBlogDbContext : DbContext
	{
		public WorldTravelBlogDbContext()
		{
		}

		public DbSet<Location> Locations { get; set; }

		public DbSet<Experience> Experiences { get; set; }

        public DbSet<Person> People { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=WorldTravelBlog;uid=root;pwd=root;");
		}

		public WorldTravelBlogDbContext(DbContextOptions<WorldTravelBlogDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}