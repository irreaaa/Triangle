class Program
{
    static void Main()
    {
        Console.WriteLine("Ввведите цифру для какой фигуры нужно выполнить расчет: треугольник(1), пирамиды(2), треугольная призма(3).");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Введите длину стороны А: ");
            double LenghtA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны B: ");
            double LenghtB = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны C: ");
            double LenghtC = Convert.ToDouble(Console.ReadLine());

            Triangle triangle = new Triangle(LenghtA, LenghtB, LenghtC);
            triangle.Proverka();
            if (triangle.IsValid == true)
            {
                double perimetr = triangle.Perimetr();
                double s = triangle.S();

                Console.WriteLine($"Периметр треугольника: {perimetr}.");
                Console.WriteLine($"Площадь треугольника по формуле Герона: {s:N2}.");
            }
        }
        if (choice == 2)
        {
            Console.WriteLine("Введите длину стороны А: ");
            double LenghtA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны B: ");
            double LenghtB = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны C: ");
            double LenghtC = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту треугольной пирамиды: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Pyramid pyramid = new Pyramid(LenghtA, LenghtB, LenghtC, height);

            double perimetr = pyramid.Perimetr();
            double s = pyramid.S();
            double sBok = pyramid.SBok();

            Console.WriteLine($"Площадь боковой поверхности: {sBok}.");
            Console.WriteLine($"Площадь треугольной пирамиды: {s:N2}.");
        }
        if (choice == 3)
        {
            Console.WriteLine("Введите длину стороны А: ");
            double LenghtA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны B: ");
            double LenghtB = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны C: ");
            double LenghtC = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту треугольной призмы: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Prism prism = new Prism(LenghtA, LenghtB, LenghtC, height);

            double perimetr = prism.Perimetr();
            double s = prism.S();
            double sBok = prism.SBok();

            Console.WriteLine($"Площадь боковой поверхности: {sBok}.");
            Console.WriteLine($"Площадь треугольной призмы: {s:N2}.");
        }
    }
}


class Triangle
{
    double LenghtA;
    double LenghtB;
    double LenghtC;
    public bool IsValid;

    protected internal Triangle(double lenghtA, double lenghtB, double lenghtC)
    {
        LenghtA = lenghtA;
        LenghtB = lenghtB;
        LenghtC = lenghtC;
    }

    protected internal virtual void Proverka()
    {
        if ((LenghtA + LenghtB > LenghtC) && (LenghtA + LenghtC > LenghtB) && (LenghtB + LenghtC > LenghtA))
        {
            IsValid = true;
            Console.WriteLine("Это треугольник.");

        }
        else
        {
            IsValid = false;
            Console.WriteLine("Фигура не является треугольником.");
        }
    }

    protected internal double Perimetr()
    {
        double perimetr = LenghtA + LenghtB + LenghtC;
        return perimetr;
    }

    protected internal virtual double S()
    {
        double poluPerimetr = (LenghtA + LenghtB + LenghtC) / 2;
        double s = Math.Sqrt(poluPerimetr * (poluPerimetr - LenghtA) * (poluPerimetr - LenghtB) * (poluPerimetr - LenghtC));
        return s;
    }
}

class Pyramid : Triangle
{
    double Height;
    protected internal Pyramid(double lenghtA, double lenghtB, double lenghtC, double height) : base(lenghtA, lenghtB, lenghtC)
    {
        Height = height;
    }

    protected internal double SBok()
    {
        double sBok = base.Perimetr() * 0.5 * Height;
        return sBok;
    }

    protected internal override double S()
    {
        double s = base.S() + 3*SBok();
        return s;
    }
}

class Prism : Triangle
{
    double Height;
    protected internal Prism(double lenghtA, double lenghtB, double lenghtC, double height) : base(lenghtA, lenghtB, lenghtC)
    {
        Height = height;
    }

    protected internal double SBok()
    {
        double sBok = base.Perimetr() * Height;
        return sBok;
    }
    protected internal override double S()
    {
        double s = base.Perimetr() / 6 * ((base.Perimetr()/3) * Math.Sqrt(3) + 6 * Height);
        return s;
    }
}