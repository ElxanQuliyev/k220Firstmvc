using System;
using System.Collections.Generic;

namespace k220Firstmvc.Models
{
    public partial class Book
    {
        public Book()
        {
            BookToGenres = new HashSet<BookToGenre>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AuthorId { get; set; }
        public string? LanguageKey { get; set; }
        public short? Quantity { get; set; }

        public virtual Author? Author { get; set; }
        public virtual ICollection<BookToGenre> BookToGenres { get; set; }
    }
}
