using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Calc
    {
        public double firstNumber { get; set; }
        public double secondNumber { get; set; }
        public string operation { get; set; }

        public Calc()
        {

        }

        public Calc(double firstnumber, double secondnumber,string oper)
        {
            firstNumber = firstnumber;
            secondNumber = secondnumber;
            operation = oper;
        }

        public double FindSolution()
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    if (secondNumber == 0)
                    {
                        return Double.NaN;
                    }
                    return firstNumber / secondNumber;
                default:
                    return Double.NaN;
            }
        }
    }
}
