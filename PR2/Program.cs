using System;

class Car
{
    public string Model { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public string Color { get; set; }
    public string AirConditioning { get; set; }
    public string Multimedia { get; set; }

    public void Show()
    {
        Console.WriteLine($"Автомобиль: {Model}, {Engine}, {Transmission}, {Color}, {AirConditioning}, {Multimedia}");
    }
}

interface ICarBuilder
{
    void BuildModel();
    void BuildEngine();
    void BuildTransmission();
    void BuildColor();
    void BuildAirConditioning();
    void BuildMultimedia();

    Car GetCar();
}

class CarBuilder : ICarBuilder
{
    private Car _car = new Car();
    public string Model { get; set; } = "Седан";
    public string Engine { get; set; } = "2л, бензин";
    public string Transmission { get; set; } = "Автомат";
    public string Color { get; set; } = "Белый";
    public string AirConditioning { get; set; } = "Есть";
    public string Multimedia { get; set; } = "Нет";

    public void BuildModel() { _car.Model = Model; }
    public void BuildEngine() { _car.Engine = Engine; }
    public void BuildTransmission() { _car.Transmission = Transmission; }
    public void BuildColor() { _car.Color = Color; }
    public void BuildAirConditioning() { _car.AirConditioning = AirConditioning; }
    public void BuildMultimedia() { _car.Multimedia = Multimedia; }

    public Car GetCar() { return _car; }
}

class CarDirector
{
    public void MakeCar(ICarBuilder builder)
    {
        builder.BuildModel();
        builder.BuildEngine();
        builder.BuildTransmission();
        builder.BuildColor();
        builder.BuildAirConditioning();
        builder.BuildMultimedia();
    }
}

class Program
{
    static void Main()
    {
        CarDirector director = new CarDirector();

        CarBuilder defaultBuilder = new CarBuilder();
        director.MakeCar(defaultBuilder);
        Car defaultCar = defaultBuilder.GetCar();
        defaultCar.Show();
    }
}