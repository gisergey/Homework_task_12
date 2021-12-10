using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    class Complex_numbers
    {
        public Complex_numbers(int real, int imagine)
        {
            Real = real;
            Imagine = imagine;
        }
        public int Real { get; set; }
        public int Imagine { get; set; }
        public static Complex_numbers operator +(Complex_numbers a, Complex_numbers b)
        {
            return new Complex_numbers(a.Real + b.Real, a.Imagine + b.Imagine);
        }
        public static Complex_numbers operator -(Complex_numbers a, Complex_numbers b)
        {
            return new Complex_numbers(a.Real - b.Real, a.Imagine - b.Imagine);
        }
        public static Complex_numbers operator *(Complex_numbers a,Complex_numbers b)
        {
            return new Complex_numbers(a.Real * b.Real - a.Imagine * b.Imagine, a.Real * b.Imagine + b.Real * a.Imagine);
        }
        public override bool Equals(object obj)
        {
            Complex_numbers a = obj as Complex_numbers;
            if (a != null&& a.Real == Real && a.Imagine == Imagine)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return Real.ToString() + " " + Imagine.ToString()+"(i)";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();

        }



    }
}
