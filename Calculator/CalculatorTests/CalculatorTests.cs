using Calculator;
using Moq;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        private readonly Mock<ICustomerDiscountCalculatorFactory> _customerCalculatorFactory;

        private readonly Dictionary<CustomerType, IDiscountCalculator> _discountCalculatorsMocks = new() {
            {CustomerType.Registered,new RegisteredCustomerDiscountCalculator()},
            {CustomerType.Valuable,new ValuableCustomerDiscountCalculator() },
            {CustomerType.MostValuable, new MostValuableCustomerDiscountCalculator() } };


        public CalculatorTests()
        {
            _customerCalculatorFactory = new Mock<ICustomerDiscountCalculatorFactory>();
        }


        [Fact]
        public void ShouldReturnSameAmountForUnregisteredCustomer()
        {
            //arrange
            var amount = 100.0m;
            var type = CustomerType.Unregistred;
            var years = 1;
            _customerCalculatorFactory.Setup(s => s.CreateDiscountCalculator(type)).
                Returns(new UnregisterdCustomerDiscountCalculator());
            
            //act
            var service = new CalculatorService(_customerCalculatorFactory.Object);
            var result = service.Calculate(amount, (int)type, years);
            
            //assert
            Assert.Equal(amount, result);
        }

        [Theory]
        [InlineData(CustomerType.Registered, 0.9, 3)]
        [InlineData(CustomerType.Valuable, 0.7, 3)]
        [InlineData(CustomerType.MostValuable, 0.5, 3)]
        [InlineData(CustomerType.Registered, 0.9, 7)]
        [InlineData(CustomerType.Valuable, 0.7, 7)]
        [InlineData(CustomerType.MostValuable, 0.5, 7)]
        public void ShouldReturnCorrectAmountForReturningCustomers(CustomerType type, double multiplier, int years)
        {
            //arrange
            var amount = 100.0m;
            if(years > 5) years = 5;
            var expectedResult = (decimal)multiplier * amount * (1 - (decimal)years / 100);
            _customerCalculatorFactory.Setup(s => s.CreateDiscountCalculator(type)).
                Returns(_discountCalculatorsMocks[type]);

            //act
            var service = new CalculatorService(_customerCalculatorFactory.Object);
            var result = service.Calculate(amount, (int)type, years);

            //assert
            Assert.Equal(expectedResult, result);
        }
    }
}