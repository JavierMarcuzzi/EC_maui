using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EC_maui
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();

            // var folder = Environment.SpecialFolder.LocalApplicationData;
            // var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(FileSystem.AppDataDirectory, "blogs.db3");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)

       //  SQLitePCL.Batteries_V2.Init();

       //   this.Database.EnsureCreated();

       //    => options.UseSqlite($"Data Source={DbPath}");
       => options.UseSqlite($"Filename={DbPath}");

    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}