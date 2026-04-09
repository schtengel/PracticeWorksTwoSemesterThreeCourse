/*Система обработки платежей (разные способы оплаты)
Создайте IPaymentHandler, CreditCardHandler, PayPalHandler, BankTransferHandler, где запрос на оплату передается по цепочке до подходящего метода.*/

using System.Runtime.CompilerServices;

public interface IPaymentHandler
{
    IPaymentHandler SetNext(IPaymentHandler handler);
    void Handle(string request);
}

public abstract class BaseHandler : IPaymentHandler
{
    private IPaymentHandler _nextHandler;

    public virtual void Handle(string request)
    {
        if (_nextHandler != null) _nextHandler.Handle(request);
        else Console.WriteLine($"Запрос {request} не обработан");
    }

    public IPaymentHandler SetNext(IPaymentHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }
}

public class CreditCardHandler : BaseHandler
{
    public override void Handle(string request)
    {
        if (request == "CreditCard") Console.WriteLine("CreditCard обработал запрос.");
        else base.Handle(request);
    }
}

public class PayPalHandler : BaseHandler
{
    public override void Handle(string request) 
    {
        if (request == "PayPal") Console.WriteLine("PayPal обработал запрос.");
        else base.Handle(request);
    }
}

public class BankTransferHandler : BaseHandler
{
    public override void Handle(string request)
    {
        if (request == "BankTransfer") Console.WriteLine("BankTransfer обработал запрос.");
        else base.Handle(request);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var creditCard = new CreditCardHandler();
        var payPal = new PayPalHandler();
        var bankTransfer = new BankTransferHandler();

        creditCard.SetNext(payPal).SetNext(bankTransfer);

        Console.WriteLine("Отправка запроса:");
        creditCard.Handle("PayPal");

        Console.WriteLine("Отправка запроса:");
        payPal.Handle("BankTransfer");

        Console.WriteLine("Отправка запроса:");
        bankTransfer.Handle("Unknown");
    }
}