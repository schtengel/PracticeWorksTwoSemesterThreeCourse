/*Конфигурационный менеджер
Создайте ConfigManager, который загружает и предоставляет настройки приложения.*/

public class ConfigManager
{
    private static readonly Lazy<ConfigManager> lazyInstance = new Lazy<ConfigManager>(() 
        => new ConfigManager());
    private ConfigManager() => Console.WriteLine("Создан экземпляр конфигурационного менеджера");
    public static ConfigManager Instance => lazyInstance.Value;
}

class Program
{
    static void Main(string[] args)
    {
        ConfigManager obj1 = ConfigManager.Instance;
        ConfigManager obj2 = ConfigManager.Instance;

        Console.WriteLine(obj1 == obj2);

        Console.WriteLine(obj1.GetHashCode());
        Console.WriteLine(obj2.GetHashCode());
    }
}