using System.Collections;   //пространсство имен для работы с объектом Stack

namespace Tower
{
    class Program
    {
        //рекурсивный метод перестановки кольца с башни from на башню to
        static void permutation(int n, Stack from, Stack to, Stack free) //free - свободная башня; n - число колец для перестановки
        {
            if (n != 0)
            {
                permutation(n - 1, from, free, to);
                to.Push(from.Pop());
                permutation(n - 1, free, to, from);
            }
        }
        static void Main(string[] args)
        {
            //Считываем какое количество колец использовать
            Console.Write("Введите число колец на левой башне: ");
            int n;
            if (!Int32.TryParse(Console.ReadLine(), out (n)))
            {
                Console.WriteLine("Введенное число содержит некорректные символы");
                return;
            }

            //частный случай
            if (n < 1)
            {
                Console.WriteLine("Число колец не может быть меньше или равно 0");
                return;
            }
            //объявляем три башни: левая, средняя, правая
            Stack left = new Stack();
            Stack middle = new Stack();
            Stack right = new Stack();

            //заполняем левую башню кольцами
            for (int i = n; i > 0; i--)
            {
                left.Push(i);
            }
            Console.WriteLine("На какую башню переложить кольца (по умолчанию перемещение на правую башню): \nmiddle or right?");

            //выбор на какую башню переместить кольца
            if (Console.ReadLine() == "middle")
            {
                Console.WriteLine("Левая Средняя Правая");
                permutation(n, left, middle, right);
                //выводим кольца со средней башни
                while (middle.Count != 0)
                {
                    Console.WriteLine($"      {middle.Pop()}");
                }
                Console.WriteLine("Перемещены кольца с левой башни на среднюю");
            }
            else
            {
                Console.WriteLine("Левая Средняя Правая");
                permutation(n, left, right, middle);
                //выводим кольца с правой башни
                while (right.Count != 0)
                {
                    Console.WriteLine($"              {right.Pop()}");
                }
                Console.WriteLine("Перемещены кольца с левой башни на правую");
            }
        }
    }
}