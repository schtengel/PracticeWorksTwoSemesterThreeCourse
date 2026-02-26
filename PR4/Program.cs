/*Пул потоков (Thread Pool)
Реализуйте пул для управления потоками выполнения (WorkerThread).*/

public class WorkerThread
{
    private static int _counter = 0;
    private int _id;

    public WorkerThread()
    {
        _id = ++_counter;
        Console.WriteLine($"Создан поток {_id}");
    }

    public void Open() => Console.WriteLine($"Поток {_id} открыт");

    public void Close() => Console.WriteLine($"Поток {_id} закрыт");


}

public class ObjectPool
{
    private List<WorkerThread> _available = new List<WorkerThread>();
    private List<WorkerThread> _inUse = new List<WorkerThread>();

    private int _maxSize;

    public ObjectPool(int maxSize)
    {
        _maxSize = maxSize;
    }

    public WorkerThread Acquire()
    {
        if( _available.Count > 0 )
        {
            var obj = _available[0];
            _available.RemoveAt(0);
            _inUse.Add(obj);
            Console.WriteLine($"Выдан поток {obj.GetHashCode()}");
            return obj;
        }
        else if (_inUse.Count < _maxSize)
        {
            var obj = new WorkerThread();
            _inUse.Add(obj);
            return obj;
        }
        else
        {
            throw new InvalidOperationException("Все потоки заняты");
        }
    }

    public void Release(WorkerThread obj)
    {
        if(_inUse.Remove(obj))
        {
            _available.Add(obj);
            Console.WriteLine($"Поток {obj.GetHashCode()} возращен в пул");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ObjectPool pool = new ObjectPool(2);

        WorkerThread thread1 = pool.Acquire();
        thread1.Open();

        WorkerThread thread2 = pool.Acquire();
        thread2.Open();

        pool.Release(thread1);
        pool.Release(thread2);

        WorkerThread thread3 = pool.Acquire();
        thread3.Open();
    }
}