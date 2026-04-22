/*Банкомат (ATM)
Создайте IATMState, NoCardState, HasCardState, HasPinState, NoCashState, ATM, чтобы управлять логикой ввода карты, ввода PIN-кода и снятия денег.*/

public interface IATMState
{
    void Handle(ATMContext context);
}

public class NoCardState : IATMState
{
    public void Handle(ATMContext context)
    {
        Console.WriteLine("Имеется ли у вас карта?");
        context.SetState(new HasCardState());
    }
}

public class HasCardState : IATMState
{
    public void Handle(ATMContext context)
    {
        Console.WriteLine("Пинкод карты: ");
        context.SetState(new HasPinState());
    }
}

public class HasPinState : IATMState
{
    public void Handle(ATMContext context)
    {
        Console.WriteLine("На карте недостаточно средств.");
        context.SetState(new NoCashState());
    }
}

public class NoCashState : IATMState
{
    public void Handle(ATMContext context)
    {
        Console.WriteLine("На карте недостаточно средств.");
    }
}

public class ATMContext
{
    private IATMState _state;

    public ATMContext()
    {
        _state = new NoCardState();
    }

    public void SetState(IATMState state)
    {
        this._state = state;
    }

    public void NextStep()
    {
        _state.Handle(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ATMContext atm = new ATMContext();

        atm.NextStep();
        atm.NextStep();
        atm.NextStep();
    }
}