using System;
using System.Collections.Generic;

namespace k220Firstmvc.Models
{
    public partial class BookToGenre
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? GenreId { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
