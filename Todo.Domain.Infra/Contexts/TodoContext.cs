using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class TodoContext: DbContext
    {
         public DbSet<TodoItem> Todos {get;set;} 

         public TodoContext(DbContextOptions options):base(options)
         {
             
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)    
         {
             modelBuilder.Entity<TodoItem>().ToTable("Todo");
             modelBuilder.Entity<TodoItem>().Property(x=>x.Id);
             modelBuilder.Entity<TodoItem>().Property(x=>x.User).HasMaxLength(120).HasColumnType("varchar(120)");
             modelBuilder.Entity<TodoItem>().Property(x=>x.Title).HasMaxLength(120).HasColumnType("varchar(120)");
             modelBuilder.Entity<TodoItem>().Property(x=>x.Done). HasColumnType("bit");
             modelBuilder.Entity<TodoItem>().Property(x=>x.Date);
             modelBuilder.Entity<TodoItem>().HasIndex(b=>b.User);
         }
    }
    
}