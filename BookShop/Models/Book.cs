using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public ICollection<Author> Autors { get; set; }
        [Required]
        public ICollection<Category> Categories { get; set; }
    }
}
