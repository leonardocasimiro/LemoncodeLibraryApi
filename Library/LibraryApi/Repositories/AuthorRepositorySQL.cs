//using EFLibrary;
using LibraryApi.Contracts;
using LibraryApi.Model;
using LibraryApi.EF;

namespace LibraryApi.Repositories
{
    public class AuthorRepositorySQL : IAuthorRepository
    {
        LibraryContext libraryContext = new LibraryContext();
    /*
    try
    {
        //soccerContext.Teams.Remove(realMadrid);
        await libraryContext.Authors.AddRangeAsync(authors);
    await libraryContext.SaveChangesAsync();
    Console.WriteLine("Data Inserted");
    }
    catch (Exception exception)
{
    Console.WriteLine(exception.ToString());
}
    */
        void IAuthorRepository.AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        void IAuthorRepository.DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        Author IAuthorRepository.GetAuthorById(int id)
        {
            //throw new NotImplementedException();
            return libraryContext.Authors.Find(id);
        }

        List<Author> IAuthorRepository.GetAuthors()
        {
            //throw new NotImplementedException();
            /*
            var libro3 = new Book
            {
                Title = "Los tropiezos de Rocinateaaaa",
                PublisedOn = new DateTime(1977, 11, 29, 19, 0, 0),
                Description = "Trata sobre los torpes pasos de este falco rocínaaaaaa flcao",
            };
            var Author2 = new Author
            {
                Name = "Tamas",
                LastName = "Terbado",
                Birth = new DateTime(1975, 11, 29, 19, 0, 0),
                CountryCode = "29603",
                Books = new List<Book> { libro3 }
            };
            var authors = new List<Author> { Author2 };
            libraryContext.Authors.AddRangeAsync(authors);
            libraryContext.SaveChangesAsync();
            */
            return libraryContext.Authors.ToList();
        }

        void IAuthorRepository.UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
