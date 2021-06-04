using System;

namespace ExamApp
{
    delegate double Operation(Delegate[] del);

    delegate int RandNum();

    class Program
    {
        static int RandNum()
        {
            Random rand = new Random();
            return rand.Next(-100, 100);
        }

        static void Main(string[] args)
        {
            Delegate[] delArray =
            {
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum),
                new RandNum(RandNum)
            };
            Operation average = delegate (Delegate[] del)
            {
                double sum = 0;
                int j = 1;
                foreach (var i in del)
                {
                    int num = (int)i.DynamicInvoke();
                    Console.WriteLine($"{j}-е число равно {num}");
                    sum += num;
                    j++;
                }
                return sum / del.Length;
            };
            Console.WriteLine("Среднее арифметическое: " + average(delArray));
        }
    }
}
