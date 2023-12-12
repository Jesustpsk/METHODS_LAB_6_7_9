namespace LAB_6to12.LABS;

public class lab_7
{
    public static void test()
    {
        SolveEquation();
        SolveLinearSystem();
        SolveLinearSystemSeidel();
    }
    private static void SolveEquation()
    {
        double x = 0;  // начальное приближение
        const double epsilon = 1e-0; // точность
        const int maxIterations = 1000; // максимальное количество итераций

        for (int i = 0; i < maxIterations; i++)
        {
            double fx = 4 * x + Math.Exp(x);

            if (Math.Abs(fx) < epsilon)
            {
                // x - приближенное решение
                Console.WriteLine($"Решение уравнения: x = {x}");
                return;
            }

            x = -fx / 4; // итерационная формула
        }

        Console.WriteLine("Метод не сошелся за заданное количество итераций.");
    }

    private static void SolveLinearSystem()
    {
        double[,] A =
        {
            { 4.003, 0.207, 0.519, 0.281 },
            { 0.416, 3.273, 0.326, 0.375 },
            { 0.297, 0.351, 2.997, 0.429 },
            { 0.412, 0.194, 0.215, 3.628 }
        };

        double[] b = { 0.425, 0.021, 0.213, 0.946 };
        double[] x = new double[4];

        const double epsilon = 1e-8;
        const int maxIterations = 1000;

        for (int k = 0; k < maxIterations; k++)
        {
            double[] newX = new double[4];

            for (int i = 0; i < 4; i++)
            {
                double sum = 0;

                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                        sum += A[i, j] * x[j];
                }

                newX[i] = (b[i] - sum) / A[i, i];
            }

            // Проверка на сходимость
            double error = 0;
            for (int i = 0; i < 4; i++)
            {
                error += Math.Abs(A[i, 0] * newX[0] + A[i, 1] * newX[1] + A[i, 2] * newX[2] + A[i, 3] * newX[3] - b[i]);
            }

            if (error < epsilon)
            {
                x = newX;
                Console.WriteLine($"Решение системы: x1 = {x[0]}, x2 = {x[1]}, x3 = {x[2]}, x4 = {x[3]}");
                return;
            }

            x = newX;
        }

        Console.WriteLine("Метод не сошелся за заданное количество итераций.");
    }

    private static void SolveLinearSystemSeidel()
    {
        double[,] A =
        {
            { 4.003, 0.207, 0.519, 0.281 },
            { 0.416, 3.273, 0.326, 0.375 },
            { 0.297, 0.351, 2.997, 0.429 },
            { 0.412, 0.194, 0.215, 3.628 }
        };

        double[] b = { 0.425, 0.021, 0.213, 0.946 };
        double[] x = new double[4];

        const double epsilon = 1e-0;
        const int maxIterations = 1000;

        for (int k = 0; k < maxIterations; k++)
        {
            for (int i = 0; i < 4; i++)
            {
                double sum1 = A[i, 0] * x[0] + A[i, 1] * x[1] + A[i, 2] * x[2] + A[i, 3] * x[3];
                double sum2 = A[i, 0] * x[0] + A[i, 1] * x[1] + A[i, 2] * x[2] + A[i, 3] * x[3];
                x[i] = (b[i] - sum1 - sum2) / A[i, i];
            }

            // Проверка на сходимость
            double error = 0;
            for (int i = 0; i < 4; i++)
            {
                error += Math.Abs(A[i, 0] * x[0] + A[i, 1] * x[1] + A[i, 2] * x[2] + A[i, 3] * x[3] - b[i]);
            }

            if (error < epsilon)
            {
                Console.WriteLine($"Решение системы: (Зейдель): x1 = {x[0]}, x2 = {x[1]}, x3 = {x[2]}, x4 = {x[3]}");
                return;
            }
        }

        Console.WriteLine("Метод не сошелся за заданное количество итераций.");
    }
}