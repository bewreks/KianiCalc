using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    public class Calculator
    {
        List<OperationType> _operationTypes = new List<OperationType>
        {
            new OperationType{name = "Сложение", number = 4, operation = typeof(Addition)},
            new OperationType{name = "Умножение", number = 2, operation = typeof(Multiply)},
            new OperationType{name = "Вычитание", number = 3, operation = typeof(Subtraction)},
            new OperationType{name = "Деление", number = 1, operation = typeof(Division)}
        };
        
        public void GetData()
        {
            void GetValue(string message, out double value)
            {
                Console.WriteLine(message);

                var input = Console.ReadLine();
                while (!double.TryParse(input, out value))
                {
                    Console.WriteLine($"Введенное значение не является числом.{Environment.NewLine}");
                    input = Console.ReadLine();
                }
            }
            
            string strOperation;

            double d_A, d_B;
            
            while (true)
            {
                GetValue("Введите первое число:", out d_A);
                
                Console.Write("Выберите операцию:" + Environment.NewLine);
                
                foreach (var type in _operationTypes.OrderBy(type => type.number))
                {
                    Console.Write($"{type.number}: {type.name}{Environment.NewLine}");
                }

                strOperation = Console.ReadLine();

                var operationType = _operationTypes.FirstOrDefault(type =>
                {
                    return type.number.ToString() == strOperation;
                });

                if (operationType == null)
                {
                    Console.WriteLine("Введенное значение не является операцией.");
                    continue;
                }

                var myOperation = (Operation) Activator.CreateInstance(operationType.operation);
                
                GetValue("Введите второе число:", out d_B);

                double operationResult = 0;
                try
                {
                    operationResult = myOperation.DoIt(d_A, d_B);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.Write($"Результат: {operationResult}");

                Console.ReadKey();
                Console.Clear();
            }
        }

        class OperationType
        {
            public int number;
            public string name;
            public Type operation;
        }
    }
}
