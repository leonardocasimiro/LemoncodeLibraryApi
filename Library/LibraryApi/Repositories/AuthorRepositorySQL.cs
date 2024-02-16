//using EFLibrary;
using LibraryApi.Contracts;
using LibraryApi.Model;
using LibraryApi.EF;

namespace LibraryApi.Repositories
{
    public class AuthorRepositorySQL : IAuthorRepository
    {
        LibraryContext libraryContext = new LibraryContext();

        void IAuthorRepository.AddAuthor(Author author)
        {
            try
            {
                // Agregar el autor al contexto
                libraryContext.Authors.Add(author);

                // Agregar lista de autores
                /*
                var authors = new List<Author> { author };
                libraryContext.Authors.AddRangeAsync(authors);
                */

                // Guardar los cambios en la base de datos
                libraryContext.SaveChanges();

                Console.WriteLine("Author added successfully.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al guardar los cambios
                Console.WriteLine($"An error occurred while adding the author: {ex.Message}");
                // Puedes lanzar una excepción personalizada o manejarla de otra manera según sea necesario
            }
        }

        void IAuthorRepository.DeleteAuthor(int id)
        {        
            // Buscar el autor por su id en el contexto
            var authorToDelete = libraryContext.Authors.Find(id);

            if (authorToDelete != null)
            {
                // Borrar el author
                libraryContext.Authors.Remove(authorToDelete);
                try
                {
                    //libraryContext.SaveChanges();
                    libraryContext.SaveChanges();
                    Console.WriteLine("Author deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while deleting the author: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Author not found.");
            }          
        }

        Author IAuthorRepository.GetAuthorById(int id)
        {
            return libraryContext.Authors.Find(id);
        }

        List<Author> IAuthorRepository.GetAuthors()
        {
            return libraryContext.Authors.ToList();
        }

        void IAuthorRepository.UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}

//Add Author;
/*
{
  "id": 2,
  "name": "Vigil",
  "lastName": "De Quiñones",
  "birth": "1824-02-16T13:39:19.175Z",
  "countryCode": "29603",
  "books": [
    {
      "id": 4,
      "title": "Rocin flaco pero sano",
      "publisedOn": "2024-02-16T13:39:19.175Z",
      "description": "Las piedras del camino"
    }
  ]
}
*/
