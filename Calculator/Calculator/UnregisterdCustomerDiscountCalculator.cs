using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class UnregisterdCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(int years)
        {
            return 0.0m;
        }

        public decimal CalculateMultiplier()
        {
            return 1;
        }
    }
}
