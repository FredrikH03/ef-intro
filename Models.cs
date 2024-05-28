namespace EFIntro;
using Microsoft.EntityFrameworkCore;

public class Post{
	public int PostId { get; set; }
	public string Title { get; set; }
	public string Content { get; set; }

	public int BlogId { get; set; }
	public Blog Blog { get; set; }
}

public class Blog {
	public int BlogId { get; set; }
	public string Url { get; set; }

	public List<Post> Posts { get; } = new();
}

public class BloggingContext : DbContext {
	public DbSet<Blog> Blogs { get; set; }
	public DbSet<Post> Posts { get; set; }

	public string DbPath { get; }

	public BloggingContext(){
		var path = Environment.CurrentDirectory;
		DbPath = System.IO.Path.Join(path, "blogging.db");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options) =>
		options.UseSqlite($"Data Source={DbPath}");

}
