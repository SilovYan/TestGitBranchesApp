using System;

namespace TestGitBranchesApp
{
    public static class CalculatorUserInterface
    {
        private static void PrintMenu()
        {
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Деление");
            Console.WriteLine("0. Выход");
        }

        private static int ReadInt(string text, int maxValue = int.MaxValue)
        {
            Console.WriteLine(text);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result > maxValue)
            {
                Console.WriteLine("Чет не то, давай еще раз");
                Console.WriteLine(text);
            }
            return result;
        }

        public static int Addition()
        {
            var a = ReadInt("Первое слогаемое:");
            var b = ReadInt("Второе слогаемое:");
            return Calculator.Addition(a, b);
        }

        public static int Subtraction()
        {
            var a = ReadInt("Уменьшаемое:");
            var b = ReadInt("Вычитаемое:");
            return Calculator.Subtraction(a, b);
        }

        public static int Division()
        {
            var a = ReadInt("Делимое:");
            var b = ReadInt("Делитель:");
            return Calculator.Division(a, b);
        }
        
        private static Func<int> AskAndGetMethod()
        {
            PrintMenu();
            var key = ReadInt("Выберите пункт:", 3);
            switch (key)
            {
                case 1:
                    return Addition;
                case 2:
                    return Subtraction;
                case 3:
                    return Division;
                default:
                    return null;
            }
        }

        public static void Run()
        {
            var calculationMethod = AskAndGetMethod();
            while (calculationMethod!=null)
            {
                Console.WriteLine("Ответ: " + calculationMethod());
                calculationMethod = AskAndGetMethod();
            }
        }
    }
}