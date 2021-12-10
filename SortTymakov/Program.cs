using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortTymakov
{
    class Program
    {
        static  List<Int64> speed = new List<Int64>();
        static  void IsTheyhavesameelements(List<int> numberssort, List<int> numbers)
        {
            List<int> num = new List<int>(numberssort);
            num.AddRange(numberssort);
            List<int> n = new List<int>(numbers);
            n.AddRange(n);

            for (int i = 0; i < n.Count; i++)
            {
                if (n.Contains(num[i]))
                {
                    n.Remove(num[i]);
                }
                else
                {
                    Console.WriteLine("Не работает");
                    break;
                }
            }
        }
        static  void Writemass(int[] numbers)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                Console.Write(numbers[i].ToString() + ' ');
            }
            Console.WriteLine();
        }
        static  void IsItWork(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Console.WriteLine("айяяяй айяяяй не работает твоя сортировка");
                    break;
                }
            }
        }
        static  List<int> Bubble(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                for (int j = 0; j < numbers.Count() - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int tmp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tmp;
                    }
                }
            }

            return numbers;
        }
        static  List<int> Insert(List<int> numbers)
        {
            int j = 0;
            int x = 0;
            for (int i = 1; i < numbers.Count(); i++)
            {
                x = numbers[i];
                j = i - 1;
                while (j > -1 && numbers[j] > x)
                {
                    if (j == i - 1) { x = numbers[j + 1]; }
                    numbers[j + 1] = numbers[j];
                    j -= 1;
                }
                numbers[j + 1] = x;

            }
            return numbers;
        }
        static  List<int> BinInsert(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count(); i++)
            {
                int rightindex = i - 1;
                int leftindex = 0;
                int x = numbers[i];
                while (Math.Abs(leftindex - rightindex) >= 2)
                {
                    int midleindex = (leftindex + rightindex) / 2;
                    if (numbers[midleindex] > x)
                    {
                        rightindex = midleindex;
                    }
                    else
                    {
                        leftindex = midleindex;
                    }

                }
                if (numbers[leftindex] >= x)
                {
                    numbers.RemoveAt(i);
                    numbers.Insert(leftindex, x);
                }
                else if (numbers[rightindex] >= x)
                {
                    numbers.RemoveAt(i);
                    numbers.Insert(leftindex + 1, x);
                }
                else
                {
                    numbers.RemoveAt(i);
                    numbers.Insert(leftindex + 2, x);
                }

            }
            return numbers;
        }

        static List<int> Quiqsort(List<int> numbers)
        {
            if (numbers.Count == 1)
            {
                return numbers;
            }
            if (numbers.Count == 2)
            {
                return new List<int>(2) { numbers.Min(), numbers.Max() };
            }

            int left = 0;
            int right = numbers.Count - 1;
            int midle = (numbers.Count - 1) / 2;
            while (left < midle | right > midle)
            {
                left = 0;
                right = numbers.Count - 1;
                while (left < midle && numbers[left] <= numbers[midle]) { left += 1; }
                while (right > midle && numbers[right] >= numbers[midle]) { right -= 1; }
                int tmp = numbers[left];
                numbers[left] = numbers[right];
                numbers[right] = tmp;
            }

            List<int> numleft = numbers.GetRange(0, midle + 1);
            List<int> sortnumbers = Quiqsort(numleft);
            List<int> numright = numbers.GetRange(midle + 1, numbers.Count - 1 - midle);
            sortnumbers.AddRange(Quiqsort(numright));
            return sortnumbers;
        }
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        static void MixHeap(int[] numbers, int length, int i)
        {
            if (length / 2 - 1 >= i)
            {
                if (i*2+1>length)
                {
                    if (numbers[i - 1] < numbers[i * 2 - 1])
                    {
                        Swap(ref numbers[i - 1], ref numbers[i * 2 - 1]);
                    }
                }
                else
                {
                    if (numbers[i * 2] > numbers[i * 2 - 1] && numbers[i * 2] > numbers[i - 1])
                    {
                        Swap(ref numbers[i * 2], ref numbers[i - 1]);
                        MixHeap(numbers,length,i*2+1);
                    }
                    else if (numbers[i * 2 - 1] > numbers[i * 2] && numbers[i * 2 - 1] > numbers[i - 1])
                    {
                        Swap(ref numbers[i * 2-1], ref numbers[i - 1]);
                        MixHeap(numbers, length, i * 2);
                    }
                }
            }


        }

        static void CreateHeap(int[] numbers, int length)
        {
            for (int i = length / 2; i > 0; i--)
            {
                MixHeap(numbers, length, i);
            }  
        }



        static void HeapSort(int[] numbers)
        {
            for(int i = numbers.Length; i >0; i--)
            {
               CreateHeap(numbers, i);
            }
  
        }
        static void Main(string[] args)
        {

            Random ran = new Random();
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan time;

            int length = 10000;
            List<int> num = new List<int>(length);
            List<int> numbers = new List<int>(length);

            for (int i = 0; i < length; i++)
            {
                numbers.Add(ran.Next(0, 1001));
            }




            
            //bubble sort
            num.Clear();
            num.AddRange(numbers);
            stopwatch.Start();
            num = Bubble(num);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды сортировка пузырьком");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
           // IsItWork(num);
           // IsTheyhavesameelements(num, numbers);

            //Insert sort           
            num.Clear();
            num.AddRange(numbers);
            stopwatch.Restart();
            num = Insert(num);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды сортировка встакой");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
            //IsItWork(num);
            //IsTheyhavesameelements(num, numbers);
            
            // Binal Insert sort
            num.Clear();
            num.AddRange(numbers);
            stopwatch.Restart();
            num = BinInsert(num);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды сортировка бинарной вставкой");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
            //IsItWork(num);
           // IsTheyhavesameelements(num, numbers);
            
            // Quick sort
            num.Clear();
            num.AddRange(numbers);
            stopwatch.Restart();
            num = Quiqsort(num);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды быстрая сортировка");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
           // IsItWork(num);
            //IsTheyhavesameelements(num, numbers);


            // Quick sort from 
            num.Clear();
            num.AddRange(numbers);
            int[] a= num.ToArray();
            stopwatch.Restart();
            a = QuickSort(a);
            stopwatch.Stop();
            num = a.ToList();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды быстрая сортировка из интернета");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
           // IsItWork(num);
           // IsTheyhavesameelements(num, numbers);

            // piramid sort
            num.Clear();
            num.AddRange(numbers);
            int[] nn = num.ToArray();
            stopwatch.Restart();
            HeapSort(nn);
            stopwatch.Stop();
            num = nn.ToList();
            num = a.ToList();
            time = stopwatch.Elapsed;
            Console.WriteLine($"{time.Minutes} минуты {time.Seconds} секунды {time.Milliseconds} миллисекунды сортировка пирамидкой");
            speed.Add(time.Minutes * 60000 + time.Seconds * 1000 + time.Milliseconds);
           // IsItWork(num);
           // IsTheyhavesameelements(num, numbers);

        }
    }
}
