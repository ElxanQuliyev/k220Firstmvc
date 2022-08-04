using System;
using System.Collections.Generic;

namespace k220Firstmvc.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BookToGenres = new HashSet<BookToGenre>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BookToGenre> BookToGenres { get; set; }
    }
}
