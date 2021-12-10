using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    class Book
    {
        public Book()
        {
            Console.WriteLine("Введите название книги");
            Name = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            Author = Console.ReadLine();
            Console.WriteLine("Введите издательство книги");
            Publisher = Console.ReadLine();
        }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
