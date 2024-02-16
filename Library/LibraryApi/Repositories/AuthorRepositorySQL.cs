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
                Console.WriteLine($"An error occurred while adding the author: {ex.Message}");
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
            try
            {
                // Buscar el autor por su id en el contexto
                var existingAuthor = libraryContext.Authors.Find(author.Id);

                if (existingAuthor != null)
                {
                    // Actualizar las propiedades del autor existente con las del autor pasado como argumento
                    existingAuthor.Name = author.Name;
                    existingAuthor.LastName = author.LastName;
                    existingAuthor.Birth = author.Birth;
                    existingAuthor.CountryCode = author.CountryCode;

                    // Guardar los cambios en la base de datos
                    libraryContext.SaveChanges();

                    Console.WriteLine("Author updated successfully.");
                }
                else
                {
                    Console.WriteLine("Author not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the author: {ex.Message}");
            }
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
