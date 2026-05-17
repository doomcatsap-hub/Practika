using System.Collections;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Ienum();
            a.Append(5);
            Console.WriteLine(a.            Enumerator);
            Console.WriteLine(a.            Enumerator);
        }

    }
    class Ienum : IEnumerable<int>
    {
        public IEnumerator<int> Enumerator
        {
            get
            {
                // Используем yield return прямо здесь!
                yield return 1;
                yield return 2;
                yield return 3;
            }
        }

        // Этот метод нужен для совместимости, просто вызывает основной
        IEnumerator IEnumerable.GetEnumerator() => Enumerator;
    }
}


