using EFIntro;

using BloggingContext? db = new();

Console.WriteLine($"SQLite directory found at {db.DbPath}");

db.Add(new Blog {Url = "first blog"});
db.Add(new Blog {Url = "second blog"});

db.SaveChanges();

Blog? blog = db.Blogs.OrderBy(b=>b.BlogId).First();

Console.WriteLine($"Blog url before update {blog.Url}");

blog.Url = "first blog but changed ";
db.SaveChanges();

blog = db.Blogs.OrderBy(b=>b.BlogId).First();
Console.WriteLine($"Blog url afterupdate {blog.Url}");

blog.Posts.Add(new Post
{
    Title = "test",
    Content = "testtest"
});

db.SaveChanges();

foreach (Blog b in db.Blogs)
{
    Console.WriteLine($"delete blog {b.Url}");
    Console.WriteLine($"Amount of posts deleted {b.Posts.Count}");
    db.Remove(b);
}
 
 db.SaveChanges();
