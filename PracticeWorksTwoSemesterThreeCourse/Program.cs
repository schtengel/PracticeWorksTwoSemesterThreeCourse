/*Фабрика автомобилей
Разработайте фабрику, создающую автомобили разных типов (седан, внедорожник) для двух брендов (например, Toyota и BMW).*/

interface ISedan { void Info(); }
interface ISUV { void Info(); }

class ToyotaSedan : ISedan
{
    public void Info() => Console.WriteLine("Седан Тойота");
}

class ToyotaSUV : ISUV
{
    public void Info() => Console.WriteLine("Внедорожник Тойота");
}

class BmwSedan : ISedan
{
    public void Info() => Console.WriteLine("Седан БМВ");
}

class BmwSUV : ISUV
{
    public void Info() => Console.WriteLine("Внедорожник БМВ");
}

interface ICarFactory
{
    ISedan CreateSedan();
    ISUV CreateSUV();
}

class ToyotaFactory : ICarFactory
{
    public ISedan CreateSedan() => new ToyotaSedan();
    public ISUV CreateSUV() => new ToyotaSUV();
}

class BmwFactory : ICarFactory
{
    public ISedan CreateSedan() => new BmwSedan();
    public ISUV CreateSUV() => new BmwSUV();
}

class Cars
{
    public List<ISedan> Sedans= new List<ISedan>();
    public List<ISUV> SUVes= new List<ISUV>();

    public void AddSedan(ISedan sedan) => Sedans.Add(sedan);
    public void AddSUV(ISUV SUV) => SUVes.Add(SUV);

    public void ShowInfo()
    {
        foreach(var s in Sedans) s.Info();
        foreach(var suv in SUVes) suv.Info();
    }
}

class Brand
{
    public Cars CreateCar(ICarFactory factory)
    {
        var cars = new Cars();
        cars.AddSedan(factory.CreateSedan());
        cars.AddSUV(factory.CreateSUV());
        
        return cars;
    }
}

class Program
{
    static void Main()
    {
        Brand brand = new Brand();

        ICarFactory toyotaFactory = new ToyotaFactory();
        Cars toyota = brand.CreateCar(toyotaFactory);

        ICarFactory bmwFactory = new BmwFactory();
        Cars bmw = brand.CreateCar(bmwFactory);

        Console.WriteLine("Авто тойоты:\n");
        toyota.ShowInfo();

        Console.WriteLine("\nАвто БМВ:\n");
        bmw.ShowInfo();
    }
}




