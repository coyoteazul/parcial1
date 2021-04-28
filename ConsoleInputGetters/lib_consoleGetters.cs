using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleGetters
{
    public static class Getters
    {
        public static string GetStringInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("Debes ingresar un valor");
                return GetStringInput(message);
            }
            else
            {
                return input;
            }
        }

        public static double GetDoubleInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double retorno))
            {
                return retorno;
            }
            else
            {
                Console.WriteLine("Debes ingresar un numero");
                return GetDoubleInput(message);
            }
        }

        public static int GetIntegerInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int retorno))
            {
                return retorno;
            }
            else
            {
                Console.WriteLine("Debes ingresar un numero entero");
                return GetIntegerInput(message);
            }
        }

        public static DateTime GetDateInput (string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime retorno))
            {
                return retorno;
            }
            else
            {
                Console.WriteLine("Debes ingresar una fecha con formato valido");
                return GetDateInput(message);
            }
        }
    }
}
