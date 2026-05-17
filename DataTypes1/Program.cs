using System.Text;

namespace DataTypes1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальный депозит");
            double initial_deposit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите количество лет");
            int years = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите процентную ставку");
            double interest_rate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(Function(initial_deposit,years, interest_rate));
        }
        static string Function(double deposit, int years, double interest_rate)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= years; i++)
            {
                deposit = Math.Round(deposit * (1 + interest_rate / 100),2);
                result.Append($"Год {i}: {deposit.ToString("0.00")} \n");
            }
            return result.ToString();
        }
    }
}
