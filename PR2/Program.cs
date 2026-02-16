class Burger
{
    public string Bun { get; set; }
    public string Patty { get; set; }
    public string Cheese { get; set; }
    public string Sauce { get; set; }
    public string Lettuce { get; set; }
    public string Tomato { get; set; }

    public void Show()
    {
        Console.WriteLine($"Бургер>: {Bun}, {Patty}, {Cheese}, {Sauce}, {Lettuce}, {Tomato}");
    }
}

interface IBurgerBuilder
{
    void BuildBun();
    void BuildPatty();
    void BuildCheese();
    void BuildSauce();
    void BuildLettuce();
    void BuildTomato();

    Burger GetBurger();
}

class BurgerBuilder : IBurgerBuilder
{
    private Burger _burger = new Burger();

    public void BuildBun() { _burger.Bun = "Булочка с кунжутом"; }
    public void BuildPatty() { _burger.Patty = "Говяжье мясо"; }
    public void BuildCheese() { _burger.Cheese = "Чеддер"; }
    public void BuildSauce() { _burger.Sauce = "Кетчуп"; }
    public void BuildLettuce() { _burger.Lettuce = "Салат айсберг"; }
    public void BuildTomato() { _burger.Tomato = "Свежие томаты"; }
    public Burger GetBurger() { return _burger; }
}

class BurgerDirector
{
    public void MakeBurger(IBurgerBuilder builder)
    {
        builder.BuildBun();
        builder.BuildPatty();
        builder.BuildCheese();
        builder.BuildSauce();
        builder.BuildLettuce();
        builder.BuildTomato();
    }
}

class Runner
{
    static void Main()
    {
        BurgerDirector director = new BurgerDirector();

        BurgerBuilder builder = new BurgerBuilder();
        director.MakeBurger(builder);
        Burger burger = builder.GetBurger();

        burger.Show();

    }
}