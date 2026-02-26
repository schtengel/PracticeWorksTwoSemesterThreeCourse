/*Фильтрация данных (разные уровни фильтрации)
Создайте IDataSource, BaseDataSource, EncryptionDecorator, CompressionDecorator, где данные могут проходить через разные фильтры.*/

public interface IDataSource
{
    void Filtration();
}

public class BaseDataSource : IDataSource
{
    public void Filtration()
    {
        Console.WriteLine("Базовая фильтрация");
    }
}

public abstract class Decorator : IDataSource
{ 
    protected IDataSource _source;

    public Decorator(IDataSource source)
        { _source = source; }

    public virtual void Filtration()
    {
        _source.Filtration();
    }
}

public class EncryptionDecorator : Decorator
{
    public EncryptionDecorator(IDataSource source) : base(source) { }

    public override void Filtration()
    {
        base.Filtration();
        Console.WriteLine("Добавлена фильтрация Encryption");
    }
}

public class CompressionDecorator : Decorator
{
    public CompressionDecorator(IDataSource source) : base(source) { }

    public override void Filtration()
    {
        base.Filtration();
        Console.WriteLine("Добавлена фильтрация Compression");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDataSource source = new BaseDataSource();
        Console.WriteLine("Базовая фильтрация: ");
        source.Filtration();

        IDataSource encryption = new EncryptionDecorator(source);
        Console.WriteLine("\nФильтрация с декоратором А: ");
        encryption.Filtration();

        IDataSource compression = new CompressionDecorator(source);
        Console.WriteLine("\nФильтрация с декоратором Б: ");
        compression.Filtration();
    }
}