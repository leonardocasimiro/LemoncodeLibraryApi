using LibraryApi.Contracts;
using LibraryApi.Model;
using Newtonsoft.Json;

namespace LibraryApi.Repositories
{
    public class AuthorRepositoryMock : IAuthorRepository
    {
        const string AUTHOR_FILE_PATH = @"C:\Leo\LemonCode\Diego\restApiLibrary\Library\LibraryApi\Resources\autores.json";
        public void AddAuthor(Author author)
        {
            List<Author> authors = GetAuthors();
            var existeAuthor = authors.Exists(a => a.Id == author.Id);
            if (existeAuthor)
                throw new Exception("Ya existe este autor.");
            authors.Add(author);
            UpdateAuthors(authors);
        }


        public void DeleteAuthor(int id)
        {
            var authors = GetAuthors();
            var indiceAuthor = authors.FindIndex(a => a.Id == id);
            if (indiceAuthor < 0)
            {
                throw new Exception("Actor no encontrado");
            }
            authors.RemoveAt(indiceAuthor);
            UpdateAuthors(authors);
        }

        Author IAuthorRepository.GetAuthorById(int id)
        {
            try
            {
                var authorsFromFile = GetAuthorFromFile();
                List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(authorsFromFile);
                return authors.FirstOrDefault(author => author.Id == id);
                //return authors[id]; //devolveria el correspondiente en la lista

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Author> GetAuthors()
        {
            try
            {
                var authorsFromFile = GetAuthorFromFile();
                List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(authorsFromFile);
                return authors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAuthor(Author author)
        {
            List<Author> authors = GetAuthors();
            var indexAuthor = authors.FindIndex(a => a.Id == author.Id);
            if (indexAuthor < 0)
                throw new Exception("Autor no encontrado");
            authors[indexAuthor] = author;
            UpdateAuthors(authors);
        }

        //##############################################
        //######   Tools ###############################
        //##############################################
        private string GetAuthorFromFile() {
            var string_json = File.ReadAllText(AUTHOR_FILE_PATH);
            return string_json;
        }

        private void UpdateAuthors(List<Author> authors)
        {
            var authorsJson = JsonConvert.SerializeObject(authors, Formatting.Indented);
            File.WriteAllText(AUTHOR_FILE_PATH, authorsJson);
        }

    }
}
