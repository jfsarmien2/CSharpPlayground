
using Microsoft.EntityFrameworkCore;

namespace TodoServiceAPI;

public class TodoDb: DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options)
    {
        
    }

    public DbSet<TodoItem> Todos { get; set; }
}
