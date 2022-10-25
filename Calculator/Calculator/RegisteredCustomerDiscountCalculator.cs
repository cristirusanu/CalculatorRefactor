namespace Calculator
{
    public class RegisteredCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateMultiplier()
        {
            return 0.9m;
        }
    }
}
