/*Интеграция старого логгера в новую систему
Создайте LoggerAdapter, который позволяет использовать старый логгер в новом приложении.*/

public interface ILogger
{
    void Request();
}

public class OldLogger
{
    public void SpecificRequest()
    {
        Console.WriteLine("Вызван метод SpecificRequest() в OldLogger.");
    }
}

public class LoggerAdapter : ILogger
{
    private readonly OldLogger _adaptee;

    public LoggerAdapter(OldLogger adaptee)
        => _adaptee = adaptee;

    public void Request()
    {
        Console.WriteLine("Адаптер преобразует вызов Request() в SpecificRequest().");
        _adaptee.SpecificRequest();
    }
}

class Program
{
    static void Main()
    {
        OldLogger oldLogger = new OldLogger();
        ILogger logger = new LoggerAdapter(oldLogger);

        Console.WriteLine("Клиент работает с адаптированным интерфейсом:");
        logger.Request();
    }
}