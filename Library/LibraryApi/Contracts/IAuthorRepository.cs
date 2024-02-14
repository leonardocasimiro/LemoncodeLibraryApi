using LibraryApi.Model;

namespace LibraryApi.Contracts
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        //void DeleteAuthorById(int id);


    }
}
