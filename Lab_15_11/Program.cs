using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            try
            {
                Console.Write("Введите начальное значение ");
                int first = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество элементов прогрессии ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите шаг прогрессии ");
                int step = Convert.ToInt32(Console.ReadLine());
                GeomProgression progression = new GeomProgression(first, step, n);
                Console.WriteLine(progression.IGetNext());
                Console.WriteLine("Сброс к начальному значению");
                progression.IReset();
                Console.Write("Введите новое начальное значение ");
                int x = Convert.ToInt32(Console.ReadLine());
                progression.ISetStart(x);
                Console.WriteLine(progression.IGetNext());
            }
            catch
            {
                Console.WriteLine("Ошибка! Входная или выходная строка имела неверный формат");
            }
            Console.ReadKey();
        }
    }
    interface ISeries
    {
        void ISetStart(int x);
        int IGetNext();
        void IReset();
    }
    public class ArithProgression : ISeries
    {
        int first;
        int step;
        int n;
        int val = 0;
        public ArithProgression(int first, int step, int n)
        {
            this.first = first;
            this.step = step;
            this.n = n;
        }
        public int IGetNext()
        {
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine(first + step * (i - 1));
            }
            return first + step * (n - 1);
        }

        public void IReset()
        {
            val = first;
        }

        public void ISetStart(int x)
        {
            first = x;
            val = first;
        }

    }
    public class GeomProgression : ISeries
    {
        int first;
        public int First
        {
            set
            {
                if (value != 0)
                {
                    first = value;
                }
                else
                {
                    Console.WriteLine("Первый элемент геометрической прогрессии не должен быть равен нулю");
                }
            }
            get
            {
                return first;
            }
        }
        int step;
        public int Step
        {
            set
            {
                if (value != 0)
                {
                    step = value;
                }
                else
                {
                    Console.WriteLine("Шаг геометрической прогрессии не должен быть равен нулю");
                }
            }
            get
            {
                return step;
            }
        }
        int n;
        int val = 1;
        public GeomProgression(int first, int step, int n)
        {
            First = first;
            Step = step;
            this.n = n;
        }
        public int IGetNext()
        {
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine(first * Math.Pow(step, i - 1));
            }
            return Convert.ToInt32(first * Math.Pow(step, n - 1));
        }

        public void IReset()
        {
            val = first;
        }

        public void ISetStart(int x)
        {
            first = x;
            val = first;
        }
    }
}
