using System;
using LAB_6to12.LABS;

class Program
{
    static void Main()
    {
        Console.WriteLine("Интерполяционный многочлен Ньютона:");
        lab_6.test();
        Console.WriteLine("_______________________________________________");
        Console.ReadKey();
        Console.WriteLine("Итерационные методы решения уравнений и систем:");
        lab_7.test();
        Console.WriteLine("_______________________________________________");
        Console.ReadKey();
        Console.WriteLine("Численное интегрирование:");
        lab_9.test();
        Console.WriteLine("_______________________________________________");
        Console.ReadKey();
    }
}
