/*Структура организации (сотрудники и отделы)
Создайте IEmployee, Employee, Department, где отделы могут включать сотрудников и подотделы.*/

public interface IEmployee
{
    void Fire();
}

public class Employee : IEmployee
{
    private string name;

    public Employee(string name)
        { this.name = name; }

    public void Fire()
    {
        Console.WriteLine($"Сотрудник {name} уволен.");
    }
}

public class Department : IEmployee
{
    private List<IEmployee> _employees = new List<IEmployee>();
    private string name;

    public Department(string name)
    { this.name = name; }

    public void Add(IEmployee employee)
    {
        _employees.Add(employee);
    }

    public void Remove(IEmployee employee)
    { _employees.Remove(employee); }

    public void Fire()
    {
        Console.WriteLine($"Сотрудники {name} уволены");
        foreach (var employee in _employees)
        {
            employee.Fire();
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        IEmployee employee1 = new Employee("Самир");
        IEmployee employee2 = new Employee("Дамир");
        IEmployee employee3 = new Employee("Марат");

        Department department1 = new Department("Отдел маркетинга");
        Department department2 = new Department("Отдел разработки");

        department1.Add(employee1);
        department1.Add(employee2);

        department2.Add(employee3);
        department2.Add(department1);

        department2.Fire();
    }
}