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

        public decimal Calculate(decimal amount, int type, int years)
        {
            IDiscountCalculator discountCalculator = new RegisteredCustomerDiscountCalculator();
            
            switch (type)
            {
                case (int)CustomerType.Unregistred:
                    discountCalculator = new UnregisterdCustomerDiscountCalculator();
                    break;
                case (int)CustomerType.Registered:
                    discountCalculator = new RegisteredCustomerDiscountCalculator();
                    break;
                case (int)CustomerType.Valuable:
                    discountCalculator = new ValuableCustomerDiscountCalculator();
                    break;
                case (int)CustomerType.MostValuable:
                    discountCalculator = new MostValuableCustomerDiscountCalculator();
                    break;
            }

            decimal discount = discountCalculator.CalculateDiscount(years);
            decimal multiplier = discountCalculator.CalculateMultiplier();
            
            return multiplier * amount * (1 - discount);
            
        }
    }
}
