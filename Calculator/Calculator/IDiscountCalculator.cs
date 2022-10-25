using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(int years)
        {
            return (years > 5) ? (decimal)5 / 100 : (decimal)years / 100;
        }

        decimal CalculateMultiplier();
    }
}
