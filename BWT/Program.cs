using System;
namespace BWT
{
    class Program
    {
        static void Main(string[] args)
        {
            int индексСтрокиВМассиве = -1;
            string исходнаяСтрока = string.Empty, закодированнаяСтрока = string.Empty;
            do
            {
                Console.Write("Введите строку : ");
                исходнаяСтрока = Console.ReadLine();
                закодированнаяСтрока = закодировать(исходнаяСтрока, ref индексСтрокиВМассиве);
                Console.WriteLine("Закодированная : {0}", закодированнаяСтрока);
                Console.WriteLine("Раскодированная: {0}", раскодировать(закодированнаяСтрока, индексСтрокиВМассиве));
                Console.WriteLine("Нажмите ESC для выхода...");
                индексСтрокиВМассиве = -1;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        public static string закодировать(string входнаяСтрока, ref int индекс)
        {
            string копияВходнойСтроки = входнаяСтрока;
            string[] массивСтрок = new string[входнаяСтрока.Length];
            char[] векторСтолбец = new char[входнаяСтрока.Length];
            массивСтрок[0] = входнаяСтрока;
            for (int i = 1; i < входнаяСтрока.Length; i++)
            {
                входнаяСтрока = входнаяСтрока.Substring(1) + входнаяСтрока[0];
                массивСтрок[i] = входнаяСтрока;
            }
            Array.Sort<string>(массивСтрок, string.CompareOrdinal);
            for (int i = 0; i < входнаяСтрока.Length; i++)
            {
                векторСтолбец[i] = массивСтрок[i][входнаяСтрока.Length - 1];
                if (копияВходнойСтроки == массивСтрок[i])
                    индекс = i;
            }
            return new string(векторСтолбец);
        }
        public static string раскодировать(string входнаяСтрока, int индекс)
        {
            string[] массивСтрок = new string[входнаяСтрока.Length];
            for (int i = 0; i < входнаяСтрока.Length; i++)
            {
                for (int j = 0; j < входнаяСтрока.Length; j++)
                    массивСтрок[j] = входнаяСтрока[j].ToString() + массивСтрок[j];
                Array.Sort<string>(массивСтрок, string.CompareOrdinal);
            }
            return массивСтрок[индекс];
        }
    }
}
