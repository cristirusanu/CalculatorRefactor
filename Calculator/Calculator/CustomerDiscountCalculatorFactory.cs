using System;
namespace Calculator
{
    public class CustomerDiscountCalculatorFactory : ICustomerDiscountCalculatorFactory
    {
        Dictionary<CustomerType, IDiscountCalculator> _discountCalculators = new() {
            {CustomerType.Unregistred,new UnregisterdCustomerDiscountCalculator() },
            {CustomerType.Registered,new RegisteredCustomerDiscountCalculator()},
            {CustomerType.Valuable,new ValuableCustomerDiscountCalculator() },
            {CustomerType.MostValuable, new MostValuableCustomerDiscountCalculator() } };

        public IDiscountCalculator CreateDiscountCalculator(CustomerType customerType)
        {
            if (!_discountCalculators.ContainsKey(customerType))
            {
                throw new ArgumentException(customerType.ToString());
            }

            return _discountCalculators[customerType];
        }
    }
}
