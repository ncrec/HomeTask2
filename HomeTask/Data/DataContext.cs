using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeTask.Domain;

namespace HomeTask.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoCategory>()
                .HasKey(bc => new { bc.TodoItemId, bc.CategoryId });
            modelBuilder.Entity<TodoCategory>()
                .HasOne(bc => bc.TodoItem)
                .WithMany(b => b.TodoCategories)
                .HasForeignKey(bc => bc.TodoItemId);
            modelBuilder.Entity<TodoCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.TodoCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
