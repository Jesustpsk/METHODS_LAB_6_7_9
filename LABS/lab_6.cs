namespace LAB_6to12.LABS;

public class lab_6
{
    
    static double NewtonInterpolation(double x, double[] xValues, double[] yValues) // Метод для вычисления значения функции с использованием интерполяционного многочлена Ньютона
    {
        int n = xValues.Length;
        double result = yValues[0];
        double[] dividedDifferences = new double[n];

        for (int i = 0; i < n; i++) // Инициализация массива разделенных разностей
        {
            dividedDifferences[i] = yValues[i];
        }

        for (int i = 1; i < n; i++) // Вычисление разделенных разностей
        {
            for (int j = n - 1; j >= i; j--)
            {
                dividedDifferences[j] = (dividedDifferences[j] - dividedDifferences[j - 1]) / (xValues[j] - xValues[j - i]);
            }

            result += dividedDifferences[n - i - 1] * CalculateTerms(xValues, i, x);
        }

        return result;
    }

    static double CalculateTerms(double[] xValues, int count, double x) // Метод для вычисления произведения (x - x_i) в интерполяционном многочлене Ньютона
    {
        double result = 1.0;

        for (int i = 0; i < count; i++)
        {
            result *= (x - xValues[i]);
        }

        return result;
    }
    public static void test()
    {
        double[] xValues1 = { 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2.0 };
        double[] yValues1 = { 0.322, 0.284, 0.241, 0.193, 0.135, 0.063, -0.031, -0.164, -0.369, -0.741, -1.664 };

        double[] xValues2 = { 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2.0 };
        double[] yValues2 = { 6.85, 5.539, 4.601, 3.902, 3.363, 2.937, 2.594, 2.313, 2.079, 1.852, 1.815 };

        // Промежуточная точка, для которой нужно вычислить значение
        double xIntermediate1 = 0.98;
        double xIntermediate2 = 1.32;

        // Вычисление значений функции в промежуточных точках
        double yIntermediate1 = NewtonInterpolation(xIntermediate1, xValues1, yValues1);
        double yIntermediate2 = NewtonInterpolation(xIntermediate2, xValues2, yValues2);

        Console.WriteLine($"Значение функции в промежуточной точке для первого промежутка: {yIntermediate1}");
        Console.WriteLine($"Значение функции в промежуточной точке для второго промежутка: {yIntermediate2}");
    }
}