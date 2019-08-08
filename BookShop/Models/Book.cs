using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }

        public ICollection<Author> Autors { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
