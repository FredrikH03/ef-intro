using System;
using System.Linq;
using EFIntro;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

foreach (Blog b in db.Blogs)
{
    Console.WriteLine($"Blog: [url: {b.Url}, amount of posts {b.Posts.Count}]");
}

foreach (Post p in db.Posts)
{
    Console.WriteLine($"post {p.Title} and content {p.Content}");
}

// Delete
Console.WriteLine("Delete the blog");
foreach (Blog test in db.Blogs) {db.Remove(test);}
db.SaveChanges();