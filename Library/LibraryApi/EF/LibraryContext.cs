using LibraryApi.Model;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.EF
{
    internal class LibraryContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=Library;user=sa;password=Lem0nCode!;Encrypt=False";
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(ConnectionString);
        }

    }
}
