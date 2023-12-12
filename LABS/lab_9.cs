namespace LAB_6to12.LABS;

public class lab_9
{
    public static void test()
    {
        // Интегрирование методом прямоугольников
        double resultRectangle = IntegrateRectangle(0, 1, 1000, x => Math.Sqrt(Math.Exp(x) + 1));
        Console.WriteLine($"Метод прямоугольников: {resultRectangle}");

        // Интегрирование методом трапеций
        double resultTrapezoid = IntegrateTrapezoid(0, 1, 1000, x => 1 / (Math.Exp(x) + 1));
        Console.WriteLine($"Метод трапеций: {resultTrapezoid}");

        // Интегрирование методом Симпсона
        double resultSimpson = IntegrateSimpson(0, Math.PI / 2, 1000, x => Math.Exp(Math.Cos(x)) * Math.Sin(x));
        Console.WriteLine($"Метод Симпсона: {resultSimpson}");

        // Вычисление аналитического результата (если возможно)
        decimal analyticalResult1 = AnalyticalResult(1);
        Console.WriteLine($"Аналитическое значение (для прямоугольников): {analyticalResult1}");
        decimal analyticalResult2 = AnalyticalResult(2);
        Console.WriteLine($"Аналитическое значение (для трапеций): {analyticalResult2}");
        decimal analyticalResult3 = AnalyticalResult(3);
        Console.WriteLine($"Аналитическое значение (метод Симпсона): {analyticalResult3}");

        // Вычисление погрешности
        decimal errorRectangle = Math.Abs(analyticalResult1 - (decimal)resultRectangle);
        decimal errorTrapezoid = Math.Abs(analyticalResult2 - (decimal)resultTrapezoid);
        decimal errorSimpson = Math.Abs(analyticalResult3 - (decimal)resultSimpson);

        Console.WriteLine($"Погрешность метода прямоугольников: {errorRectangle}");
        Console.WriteLine($"Погрешность метода трапеций: {errorTrapezoid}");
        Console.WriteLine($"Погрешность метода Симпсона: {errorSimpson}");
    }

    // Метод прямоугольников
    static double IntegrateRectangle(double a, double b, int n, Func<double, double> func)
    {
        double h = (b - a) / n;
        double result = 0.0;

        for (int i = 0; i < n; i++)
        {
            double x = a + i * h;
            result += func(x);
        }

        return result * h;
    }

    // Метод трапеций
    static double IntegrateTrapezoid(double a, double b, int n, Func<double, double> func)
    {
        double h = (b - a) / n;
        double result = (func(a) + func(b)) / 2.0;

        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            result += func(x);
        }

        return result * h;
    }

    // Метод Симпсона
    static double IntegrateSimpson(double a, double b, int n, Func<double, double> func)
    {
        if (n % 2 != 0)
            throw new ArgumentException("Число отрезков должно быть четным.");

        double h = (b - a) / n;
        double result = func(a) + func(b);

        for (int i = 1; i < n; i += 2)
        {
            double x = a + i * h;
            result += 4 * func(x);
        }

        for (int i = 2; i < n - 1; i += 2)
        {
            double x = a + i * h;
            result += 2 * func(x);
        }

        return result * h / 3;
    }

    // Аналитическое значение (если возможно)
    static decimal AnalyticalResult(int func)
    {
        return func switch
        {
            1 => (decimal)1.64205578028158,
            2 => (decimal)0.3798854930417225,
            3 => (decimal)1.718281828459045,
            _ => 0
        };
    }
}