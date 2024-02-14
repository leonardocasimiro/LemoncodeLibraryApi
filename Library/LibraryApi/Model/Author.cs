namespace LibraryApi.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; }

        //Navigation Properties
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
