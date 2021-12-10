using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    class Bookcontainer
    {

        List<Book> books = new List<Book>();
        public List<Book> Books
        {
            get { return books; }
        }
        public void Add_book()
        {
            books.Add(new Book());
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < books.Count(); i++)
            {
                s += books[i].Name + ' ' + books[i].Author + ' ' + books[i].Publisher + '\n';
            }
            return s;
        }
    }
}
