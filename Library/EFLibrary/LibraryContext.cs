using EFLibrary.Entities;
using Microsoft.EntityFrameworkCore;


namespace EFLibrary
{
    internal class LibraryContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=Library;user=sa;password=Lem0nCode!;Encrypt=False";
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(ConnectionString);
        }

    }
}
