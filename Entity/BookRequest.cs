using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class BookRequest
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public bool IsBookReturned { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
