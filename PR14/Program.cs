/*Парсер логических выражений
Создайте ILogicExpression, AndExpression, OrExpression, NotExpression, VariableExpression, 
чтобы интерпретировать логические выражения, такие как "true AND (false OR true)".*/

public interface ILogicExpression
{
    bool Interpret();
}

public class VariableExpression : ILogicExpression
{
    private bool _value;

    public VariableExpression(bool value)
    {
        this._value = value;
    }

    public bool Interpret() => _value;
}

public class AndExpression : ILogicExpression
{
    private ILogicExpression _left;
    private ILogicExpression _right;

    public AndExpression(ILogicExpression left, ILogicExpression right)
    {
        _left = left;
        _right = right;
    }

    public bool Interpret() => _left.Interpret() && _right.Interpret();
}

public class OrExpression : ILogicExpression
{
    private ILogicExpression _left;
    private ILogicExpression _right;

    public OrExpression(ILogicExpression left, ILogicExpression right)
    {
        _left = left;
        _right = right;
    }

    public bool Interpret() => _left.Interpret() || _right.Interpret();
}

public class NotExpression : ILogicExpression
{
    private ILogicExpression _value;

    public NotExpression(ILogicExpression value) => _value = value;

    public bool Interpret() => !_value.Interpret();
}


class Program
{
    static void Main(string[] args)
    {
        ILogicExpression logicExpression = new AndExpression(
            new OrExpression(new VariableExpression(true), new VariableExpression(false)), new VariableExpression(true));

        bool result = logicExpression.Interpret();
        Console.WriteLine("Результат равен: " + result);
    }
}