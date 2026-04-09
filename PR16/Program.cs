/*Подписка на новости
Создайте INewsSubject, NewsAgency, INewsObserver, Subscriber, чтобы пользователи получали уведомления о новых статьях.*/

public interface INewsObserver
{
    void Update(string article);
}

public interface INewsSubject
{
    void Attach(INewsObserver observer);
    void Detach(INewsObserver observer);
    void Notify();
}

public class NewsAgency : INewsSubject
{
    private List<INewsObserver> _observer = new List<INewsObserver>();
    private string _article;

    public void Attach(INewsObserver observer)
    {
        _observer.Add(observer);
    }

    public void Detach(INewsObserver observer)
    {
        _observer.Remove(observer);
    }

    public void Notify()
    {
        foreach(var observer in _observer)
        {
            observer.Update(_article);
        }
    }

    public void SetArticle(string article)
    {
        _article = article;
        Notify();
    }
}

public class PhoneSubscriber : INewsObserver
{
    private string _deviceName;

    public PhoneSubscriber(string deviceName)
    {
        this._deviceName = deviceName;
    }

    public void Update(string article)
    {
        Console.WriteLine($"Телефон {_deviceName}: вышла новая статья -> {article}");
    }
}

public class TvSubscriber : INewsObserver
{
    private string _deviceName;

    public TvSubscriber(string deviceName)
    {
        this._deviceName = deviceName;
    }

    public void Update(string article)
    {
        Console.WriteLine($"Телевизор {_deviceName}: вышла новая статья -> {article}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        NewsAgency agency = new NewsAgency();

        PhoneSubscriber phone1 = new PhoneSubscriber("iPhone 11");
        PhoneSubscriber phone2 = new PhoneSubscriber("Samsung S24");
        TvSubscriber tv1 = new TvSubscriber("LG TV");
        TvSubscriber tv2 = new TvSubscriber("Эмеральд");

        agency.Attach(phone1);
        agency.Attach(phone2);
        agency.Attach(tv1);
        agency.Attach(tv2);

        agency.SetArticle("Новые фишки Android 17");
        agency.SetArticle("Что изменится в iOS 27");

        agency.Detach(phone1);
        agency.Detach(tv2);

        agency.SetArticle("Почему Microsoft делает ИИ-слоп");

    }
}

