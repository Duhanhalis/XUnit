namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public class Calculator
        {
            public int Add(int a, int b) => a + b;
            public int Divide(int a, int b) => a / b;
        }
    }
}