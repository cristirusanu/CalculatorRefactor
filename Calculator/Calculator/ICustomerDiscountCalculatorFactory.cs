namespace Calculator
{
    public interface ICustomerDiscountCalculatorFactory
    {
        IDiscountCalculator CreateDiscountCalculator(CustomerType customerType);
    }
}