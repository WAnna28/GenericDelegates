using System;

// C# allows you to define generic delegate types.
// For example, assume you want to define a delegate type that can call
// any method returning void and receiving a single parameter.
// If the argument in question may differ, you could model this using a type parameter.
namespace GenericDelegates
{
    class Program
    {
        static void Main()
        {
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            //Using the method group conversion syntax
            MyGenericDelegate<int> intTarget = IntTarget;
            intTarget(9);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // The generic Action<> delegate is defined in the System namespace, and you can use this generic
            // delegate to “point to” a method that takes up to 16 arguments(that ought to be enough!) and returns void.
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // The generic Func<> delegate can point to methods that (like Action<>) take up to 16 parameters and a
            // custom return value.
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("\n40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);
           
            Console.ReadLine();

            static void StringTarget(string arg)
            {
                Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
            }

            static void IntTarget(int arg)
            {
                Console.WriteLine("++arg is: {0}", ++arg);
            }
        }

        // This generic delegate can represent any method
        // returning void and taking a single parameter of type T.
        public delegate void MyGenericDelegate<T>(T arg);

        // This is a target for the Action<> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            Console.WriteLine();

            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color.
            Console.ForegroundColor = previous;
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Add2(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}