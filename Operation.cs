using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    public abstract class Operation
    {
        public abstract double DoIt(double num1, double num2);
    }

    public class Addition : Operation
    {
        public override double DoIt(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Subtraction : Operation
    {
        public override double DoIt(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Multiply : Operation
    {
        public override double DoIt(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Division : Operation
    {
        public override double DoIt(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new Exception("Деление на 0!");
            }

            return num1 / num2;
        }
    }
}
