using Microsoft.EntityFrameworkCore;
using orm.Models;

namespace orm.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<ContactData> ContactDatas { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
