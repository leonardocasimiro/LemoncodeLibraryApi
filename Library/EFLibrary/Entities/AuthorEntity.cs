using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Entities
{
    internal class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; }

        //Navigation Properties
        public List<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
