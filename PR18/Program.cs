/*Способы оплаты в интернет-магазине
Создайте IPaymentStrategy, CreditCardPayment, PayPalPayment, BitcoinPayment, PaymentProcessor, чтобы пользователь мог выбрать способ оплаты.*/

public interface IPaymentStrategy
{
    void Pay(double amount);    
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(double amount) 
    {
        Console.WriteLine($"Оплата с использованием банковской карты {amount}");
    }
}
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата с использованием PayPal {amount}");
    }
}

public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата с использованием биткоина {amount}");
    }
}

public class PaymentProcessor
{
    private IPaymentStrategy _strategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy )
    {
        _strategy = strategy;
    }

    public void ExecutePayment(double amount)
    {
        if( _strategy == null )
        {
            Console.WriteLine("Ошибка: метод оплаты не выбран!");
            return;
        }

        _strategy.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        PaymentProcessor context = new PaymentProcessor();

        Console.WriteLine("Выберите метод оплаты:");
        Console.WriteLine("1 - Банковская карта");
        Console.WriteLine("2 - PayPal");
        Console.WriteLine("3 - Биткоин");

        string choice = Console.ReadLine();
        double amount = 500.0;

        switch (choice)
        {
            case "1":
                context.SetPaymentStrategy(new CreditCardPayment());
                break;
            case "2":
                context.SetPaymentStrategy(new PayPalPayment());
                break;
            case "3":
                context.SetPaymentStrategy(new BitcoinPayment());
                break;
            default:
                Console.WriteLine("Ошибка: некорректный выбор.");
                return;
        }

        context.ExecutePayment(amount);
    }
}