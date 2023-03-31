using CSD.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CSD.Web.Data;

public class CSDContext : DbContext
{
    public CSDContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
}