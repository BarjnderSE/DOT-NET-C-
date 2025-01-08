using BlogMe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogMe.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
