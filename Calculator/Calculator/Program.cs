using Calculator;
using Microsoft.Extensions.DependencyInjection;

//setup our DI
var serviceProvider = new ServiceCollection()
                .AddSingleton<ICustomerDiscountCalculatorFactory, CustomerDiscountCalculatorFactory>()
                .BuildServiceProvider();

Console.WriteLine("Hello, World!");

CalculatorService calcService = new(customerDiscountCalculatorFactory: serviceProvider.GetService<ICustomerDiscountCalculatorFactory>());


Console.WriteLine(calcService.Calculate(100.0m, 2, 6));
Console.ReadLine();
