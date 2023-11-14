using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Если значение не является числом, то в ходе выполнения может произойти ошибка.

            // Используйте оператор switch для выполнения математичеких операций.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Попросить пользователя ввести ненулевой делитель.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Вернуть текст при неккоретном вводе.
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display tittle as the C# console calculator app.
            Console.WriteLine("Калькулятор в режиме консоль на C#");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Ввод переменных и присвоение им значения 0.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Попросить пользователя ввести первое число.
                Console.Write("Введите число, а затем нажмите Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Недопустимое значение, введите целое число: ");
                    numInput1 = Console.ReadLine();
                }

                // Попросить пользователя ввести второе число.
                Console.Write("Введите еще одно число, а затем нажмите Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Недопустимое значение, введите целое число: ");
                    numInput2 = Console.ReadLine();
                }

                // Попросить пользователя выбрать действие.
                Console.WriteLine("Выберите действие из следующего списка:");
                Console.WriteLine("\ta - Сложить");
                Console.WriteLine("\ts - Вычесть");
                Console.WriteLine("\tm - Сложить");
                Console.WriteLine("\td - Разделить");
                Console.Write("Ваш выбор? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Эта операция приведет к математической ошибке.\n");
                    }
                    else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("О боже! Произошло исключение при попытке выполнить математическое вычисление.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Дождаться ответа пользователя перед закрытием.
                Console.Write("Нажмите 'n' и Enter для закрытия приложения, или нажмите любую другую клавишу и Enter для продолжения: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Удобный межстрочный интервал.
            }
            return;
        }
    }
}

