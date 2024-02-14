// See https://aka.ms/new-console-template for more information
using EFLibrary.Entities;
using EFLibrary;


Console.WriteLine("Press [ENTER] to end");
await AddAuthors();
Console.ReadLine();

static async Task AddAuthors()
{
    // Lista de equipos
    var libro1 = new BookEntity { 
        Title = "Poesias rotas",
        PublisedOn = new DateTime(1975, 11, 29, 19, 0, 0),
        Description = "Poesias de amor destruidas",
    };
    var libro2 = new BookEntity
    {
        Title = "El otro Sancho",
        PublisedOn = new DateTime(1976, 11, 29, 19, 0, 0),
        Description = "Pensamientos de Sancho y los recuerdos de los que le conocieron",
    };
    var libro3 = new BookEntity
    {
        Title = "Los tropiezos de Rocinate",
        PublisedOn = new DateTime(1977, 11, 29, 19, 0, 0),
        Description = "Trata sobre los torpes pasos de este falco rocín",
    };
    var books = new List<BookEntity> { libro1, libro2, libro3 };

    //Lista de Autores
    var Author1 = new AuthorEntity
    {
        Name = "Roberto",
        LastName = "Iniesta",
        Birth = new DateTime(1975, 11, 29, 19, 0, 0),
        CountryCode = "29603",
        Books = new List<BookEntity> {libro1, libro2}
    };
    var Author2 = new AuthorEntity
    {
        Name = "Benito",
        LastName = "Carmela",
        Birth = new DateTime(1975, 11, 29, 19, 0, 0),
        CountryCode = "29603",
        Books = new List<BookEntity> { libro3 }
    };
    var authors = new List<AuthorEntity> { Author1, Author2 };

    //Añadimos Autores y Libros
    await using var libraryContext = new LibraryContext();
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
}
