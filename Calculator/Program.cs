using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа \"Калькулятор\"!");
            Console.WriteLine("\nМы умеем:");
            Console.WriteLine("складывать \t(код действия 1),\nвычитать \t(код действия 2),\nумножать \t(код действия 3),\nделить \t\t(код действия 4)");
            Console.WriteLine("");

            #region Действия                   
            try
            {
                /*
                  Получаем данные, если код действия не подходит, вызываем исключение ArgumentOutOfRangeException.
                  Наверно при использовании такого принудительно вызова ошибки можно было бы и string задавать в качестве кода действия (н-р "*").
                  Но решила оставить как в условии сказано
                */
                Console.WriteLine("Для начала прошу Вас ввести первое число");
                Console.Write("\t");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Прошу Вас ввести второе число");
                Console.Write("\t");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Прошу ввести код действия с числами");
                Console.Write("\t");
                int action = Convert.ToInt32(Console.ReadLine());
                if ((action < 1) || (action > 4))
                {
                    throw new ArgumentOutOfRangeException();
                }

                double result = 0;
                /*
                  В зависимости от действий определяем расчёт результата. Для деления на 0 вызываем ошибку DividedByZeroException
                */
                if (action == 1)                
                    result = a + b;                
                else if (action == 2)                
                    result = a - b;
                else if (action == 3)                
                    result = a * b;                
                else if (action == 4)                
                    if (b == 0)                    
                        throw new DivideByZeroException();                    
                    else                    
                        result = a / b;                  
                
                Console.WriteLine("Ваш результат {0:f2}", result);
            }
            catch (FormatException)
            {
                Console.WriteLine("К сожалению, это не похоже на число или код действия. Не верен формат входных данных");                
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Коды действия ограничены числами от 1 до 4.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }           
            
            #endregion

            Console.WriteLine("Нажмите любую кнопку для закрытия программы");
            Console.ReadKey();

        }
    }
}
