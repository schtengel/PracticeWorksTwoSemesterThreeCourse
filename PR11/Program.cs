/*Компьютерная система (включение и управление компонентами)
Создайте ComputerFacade, который управляет CPU, Memory, HardDrive, PowerSupply, упрощая процесс загрузки системы.*/

using System;

public class CPU
{
    public void Info() => Console.WriteLine("AMD Ryzen R5 8400f");
}

public class Memory
{
    public void Info() => Console.WriteLine("KingBank DIMM 16x2 Gb 6000Ghz");
}

public class HardDrive
{
    public void Info() => Console.WriteLine("SSD.M2 ADATA Legend 900 512 Gb");
}

public class PowerSupply
{
    public void Info() => Console.WriteLine("SuperFlower 750W Bronze");
}

public class ComputerFacade
{
    private readonly CPU _cpu;
    private readonly Memory _memory;
    private readonly HardDrive _drive;
    private readonly PowerSupply _powerSupply;

    public ComputerFacade()
    {
        _cpu = new CPU();
        _memory = new Memory();
        _drive = new HardDrive();
        _powerSupply = new PowerSupply();
    }

    public void OperationSimplified()
    {
        Console.WriteLine("Компьютер: ");
        _cpu.Info();
        _memory.Info();
        _drive.Info();
        _powerSupply.Info();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ComputerFacade computerFacade = new ComputerFacade();

        Console.WriteLine("Клиент использует фасад");
        computerFacade.OperationSimplified();
    }
}