/*Диспетчеризация авиарейсов
Создайте IAirTrafficMediator, Airplane, ControlTower, где башня управления регулирует взлёты и посадки самолётов, координируя их между собой*/

public interface IAirTrafficMediator
{
    void TakeOffPlane(string message, Airplane sender);
}

public class ChatMediator : IAirTrafficMediator
{
    private List<Airplane> _airplanes = new List<Airplane>();

    public void Register(Airplane colleague) => _airplanes.Add(colleague);

    public void TakeOffPlane(string message, Airplane sender)
    {
        foreach(var colleague in _airplanes)
            if(colleague != sender) colleague.ReceiveMessage(message);
    }
}

public abstract class Airplane
{
    protected IAirTrafficMediator _mediator;

    public Airplane(IAirTrafficMediator mediator) => _mediator = mediator;

    public abstract void ReceiveMessage(string message);
}

public class ControlTower : Airplane
{
    private string _name;

    public ControlTower(IAirTrafficMediator mediator, string name) : base(mediator) => _name = name;

    public void TakeOffPlane(string message)
    {
        Console.WriteLine($"{_name} отправляет самолет {message} в полет.");
        _mediator.TakeOffPlane(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name} получает сообщение об отправке {message} в полет.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ChatMediator chatMediator = new ChatMediator();

        ControlTower controlTower1 = new ControlTower(chatMediator, "ПС-4537");
        ControlTower controlTower2 = new ControlTower(chatMediator, "AS-3941");
        ControlTower controlTower3 = new ControlTower(chatMediator, "HD-4289");

        chatMediator.Register(controlTower1);
        chatMediator.Register(controlTower2);
        chatMediator.Register(controlTower3);

        controlTower1.TakeOffPlane("Boieng-73");
        controlTower2.TakeOffPlane("Boieng-71");
        controlTower3.TakeOffPlane("Самолетик кузи");
    }
}