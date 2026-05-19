using System.Globalization;
using System.Runtime.InteropServices;

namespace OOP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату x");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координату y");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите ширину");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите длину");
            double b = Convert.ToDouble (Console.ReadLine()); 
            Rectangle rectangle1 = new(x,y,a,b);
            rectangle1.ShowPerimeterSquare();

        }
    }

    public class Rectangle
    {
        double x, y, Width, Hight;
        public Rectangle(double x, double y, double Width, double Hight)
        {
            if (Width <= 0 || Hight <= 0)
                throw new ArgumentException("Ширина и длина не могут быть меньше или равны 0");
            this.y = y;
            this.x = x;
            this.Width = Width;
            this.Hight = Hight;
        }
        public double Perimeter
        {
            get { return (Hight + Width) * 2; }
        }
        public double Square
        {
            get { return Hight * Width; }
        }
        public void ShowPerimeterSquare()
        {
            Console.WriteLine($"Периметр - {Perimeter}, Площадь - {Square} ");

        }
    }
}

