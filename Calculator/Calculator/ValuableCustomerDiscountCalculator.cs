namespace Calculator
{
    public class ValuableCustomerDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateMultiplier()
        {
            return 0.7m;
        }
    }
}
