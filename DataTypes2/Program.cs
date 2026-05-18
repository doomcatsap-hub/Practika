namespace DataTypes2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину диагоналей (нечетное положительное число)");
            int N = Convert.ToInt32(Console.ReadLine());
            Rhomb(N);
        }
        static void Rhomb(int N)
        {

            int mid = N / 2;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (j == (Math.Abs(mid - i)) || (j == mid + i) || (j == N-1 - i + mid))
                        Console.Write('X');
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }

        }
    }
}
