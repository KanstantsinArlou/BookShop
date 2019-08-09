using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [Required]
        DateTime DateOfBirth { get; set; }
        DateTime DateOfDeath { get; set; }
        public string Biography { get; set; }
    }
}
