public class Downloader
{
    public delegate Task DownloadCompletedHandler(object sender, string fileName);
    public event DownloadCompletedHandler DownloadCompleted;

    public async Task StartDownloadAsync(string fileName)
    {
        Console.WriteLine($"Начата загрузка файла: {fileName}");
        await Task.Delay(3000);
        Console.WriteLine($"Загрузка завершена: {fileName}");
        await RaiseDownloadCompleted(fileName);
    }

    private async Task RaiseDownloadCompleted(string fileName)
    {
        var handlers = DownloadCompleted?.GetInvocationList();
        if (handlers == null) return;

        foreach(var handler in handlers.Cast<DownloadCompletedHandler>())
        {
            await handler(this, fileName);
        }
    }
}

public class Program
{
    static  async Task Main()
    {
        var downloader = new Downloader();

        downloader.DownloadCompleted += OnDownloadCompleted;

        await downloader.StartDownloadAsync("report.pdf");
    }

    private static async Task OnDownloadCompleted(object sender, string fileName)
    {
        Console.WriteLine($"Уведомление: файл {fileName} обработан!");
        await Task.CompletedTask;
    }
}