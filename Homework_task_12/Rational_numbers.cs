using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task_12
{
    class Rational_numbers
    {
        private void Cut()
        {
            int b = Math.Abs(numerals);
            int c = Math.Abs(denominator);
            while (c != b)
            {
                if (c > b)
                {
                    c -= b;
                }
                else
                {
                    b -= c;
                }
            }
            if (numerals < 0 && denominator < 0)
            {
                c *= -1;
            }
           numerals= numerals / c;
           denominator=denominator / c;

        }
        public Rational_numbers(int num, int den=1)
        {
            numerals = num;
            denominator = den;
            Cut();

        }
        private int numerals;
        private int denominator;
        public int Numerals
        {
            get { return numerals; }
            set { numerals = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }

        public static Rational_numbers operator +(Rational_numbers a, Rational_numbers b)
        {
            return new Rational_numbers(a.Numerals * b.Denominator + b.Numerals * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Rational_numbers operator -(Rational_numbers a, Rational_numbers b)
        {
            return new Rational_numbers(a.Numerals * b.Denominator - b.Numerals * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Rational_numbers operator ++(Rational_numbers a)
        {
            return new Rational_numbers(a.Numerals + a.Denominator,a.Denominator) ;
        }
        public static Rational_numbers operator --(Rational_numbers a)
        {
            return new Rational_numbers(a.Numerals - a.Denominator, a.Denominator);
        }

        public static bool operator <(Rational_numbers a,Rational_numbers b)
        {
            if (a.Numerals * b.Denominator < b.Numerals * a.Denominator)
            {
                return true;
            }
            return false;
        }
        public static bool operator >(Rational_numbers a, Rational_numbers b)
        {
            if (a.Numerals * b.Denominator > b.Numerals * a.Denominator)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Rational_numbers a, Rational_numbers b)
        {
            if (a.Numerals * b.Denominator <= b.Numerals * a.Denominator)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Rational_numbers a, Rational_numbers b)
        {
            if (a.Numerals * b.Denominator >= b.Numerals * a.Denominator)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Rational_numbers a, Rational_numbers b)
        {
            if (a.Denominator == b.Denominator && a.Numerals == b.Numerals)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Rational_numbers a, Rational_numbers b)
        {
            if (a.Denominator == b.Denominator && a.Numerals == b.Numerals)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            Rational_numbers a = obj as Rational_numbers;
            if (a!=null&& a.Denominator == denominator && a.Numerals == numerals)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return numerals.GetHashCode()+denominator.GetHashCode();
        }
        public override string ToString()
        {
            return numerals.ToString() + '/' + denominator.ToString();
        }

        public float ToFloat()
        {
            return (float)numerals / denominator;
        }
        public int ToInt()
        {
            return (int)numerals / denominator;
        }


        public static Rational_numbers operator *(Rational_numbers a, Rational_numbers b)
        {
            return new Rational_numbers(a.Numerals * b.Numerals, a.Denominator * b.Denominator);
        }
        public static Rational_numbers operator /(Rational_numbers a, Rational_numbers b)
        {
            return new Rational_numbers(a.Numerals * b.Denominator, a.Denominator * b.Numerals);
        }
        public static Rational_numbers operator %(Rational_numbers a,Rational_numbers b)
        {
            Rational_numbers c = new Rational_numbers(a.Numerals,a.Denominator);
            Rational_numbers d = new Rational_numbers(b.Numerals, b.Denominator);
            if (c< new Rational_numbers(0))
            {
                c *= new Rational_numbers(-1);
            }
            if (d<  new Rational_numbers(0))
            {
                d *= new Rational_numbers(-1);
            }

            while (c > d)
            {
                c -= d;
            }
            return c;
        }



    }
}
