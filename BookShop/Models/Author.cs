using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        DateTime DateOfDirth { get; set; }
        DateTime DateOfDeath { get; set; }
        public string Biography { get; set; }
    }
}
