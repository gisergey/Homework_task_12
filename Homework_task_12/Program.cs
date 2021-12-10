
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    delegate void SortBooks(List<Book> books);
    class Program
    {
         
        static void Main(string[] args)
        {
            // task 12.1
            bankaccount acc = new bankaccount(93, accounts.saving);
            Console.WriteLine(acc.ToString());
            // task 12.1(2)
            Complex_numbers a = new Complex_numbers(2, 3);
            Complex_numbers b = new Complex_numbers(5, -2);
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine((a - b).ToString());
            Console.WriteLine((a + b).ToString());
            Console.WriteLine((a * b).ToString());
            // task 12.2(2)
            Console.WriteLine("Введите количесво книг");
            int number;
            while(!int.TryParse(Console.ReadLine(),out number))
            {
                Console.WriteLine("Вы ввели не число попробуйте еще раз");
            }
            Bookcontainer bookscont = new Bookcontainer();
            for (int i = 0; i < number; i++)
            {
                bookscont.Add_book();
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите как осортировать контейнер: имя, автор, издатель");
                string line = Console.ReadLine();
                if (line.Equals("имя"))
                {
                    SortBooks sort = SortBooksbyName;
                    sort(bookscont.Books);
                    Console.WriteLine(bookscont.ToString());
                    flag = false;
                }
                else if (line.Equals("автор"))
                {
                    SortBooks sort = SortBooksbyAuthor;
                    sort(bookscont.Books);
                    Console.WriteLine(bookscont.ToString());
                    flag = false;
                }
                else if (line.Equals("издатель"))
                {
                    SortBooks sort = SortBooksbyPyblisher;
                    sort(bookscont.Books);
                    Console.WriteLine(bookscont.ToString());
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Команда не распозана попробуйте еще раз");
                }
            }



        }
        static public bool IsStringFirster(string str1, string str2)
        {
            bool flag = true;
            for (int i = 0; i < ((str1.Count() > str2.Count()) ? str2.Count() : str1.Count()); i++)
            {
                if ((int)str1[i] > (int)str2[i])
                {
                    flag = false;
                    break;
                }
            }
            if (flag) { flag = !(str1.Count() > str2.Count()); }
            return flag;
        }
        static public void SortBooksbyName(List<Book> books)
        {
            for (int j = books.Count - 1; j > 1; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (!IsStringFirster(books[i].Name, books[i + 1].Name))
                    {
                        Book tmp = books[i];
                        books[i] = books[i + 1];
                        books[i + 1] = tmp;
                    }
                }
            }
        }
        static public void SortBooksbyAuthor(List<Book> books)
        {
            for (int j = books.Count - 1; j > 1; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (!IsStringFirster(books[i].Author, books[i + 1].Author))
                    {
                        Book tmp = books[i];
                        books[i] = books[i + 1];
                        books[i + 1] = tmp;
                    }
                }
            }
        }
        static public void SortBooksbyPyblisher(List<Book> books)
        {
            for (int j = books.Count - 1; j > 1; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (!IsStringFirster(books[i].Publisher, books[i + 1].Publisher))
                    {
                        Book tmp = books[i];
                        books[i] = books[i + 1];
                        books[i + 1] = tmp;
                    }
                }
            }
        }
    }
}
