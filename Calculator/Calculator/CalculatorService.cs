using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Discount Manager: Calculate a discount from a 
 * customer type (unregistered, registered, valuable, most valuable) 
 * and a time of having an account in years
 */

namespace Calculator
{
    public class CalculatorService : ICalculator
    {
        ICustomerDiscountCalculatorFactory _customerDiscountCalculatorFactory;
        public CalculatorService(ICustomerDiscountCalculatorFactory customerDiscountCalculatorFactory)
        {
            _customerDiscountCalculatorFactory = customerDiscountCalculatorFactory;
        }

        public decimal Calculate(decimal amount, int type, int years)
        {
            var discountCalculator = _customerDiscountCalculatorFactory.CreateDiscountCalculator((CustomerType)type);

            decimal discount = discountCalculator.CalculateDiscount(years);
            decimal multiplier = discountCalculator.CalculateMultiplier();

            return multiplier * amount * (1 - discount);
        }
    }
}
