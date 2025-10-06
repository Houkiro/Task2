using System.Diagnostics;

var stopwatch = new Stopwatch();

Console.WriteLine("Начало синхронных задач\n");
stopwatch.Start();
Console.WriteLine(ProcessData("Файл 1"));
Console.WriteLine(ProcessData("Файл 2"));
Console.WriteLine(ProcessData("Файл 3"));
stopwatch.Stop();
var syncTime = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"\nЗавершение синхронных задач. Время: {syncTime:F3} сек\n");

Console.WriteLine("Начало асинхронных задач\n");
stopwatch.Restart();
string[] results = await Task.WhenAll(
    ProcessDataAsync("Асинхронно файл 1"),
    ProcessDataAsync("Асинхронно файл 2"),
    ProcessDataAsync("Асинхронно файл 3")
);

stopwatch.Stop();
var asyncTime = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine($"Завершение асинхронных задач. Время: {asyncTime:F3} сек\n");

foreach (string result in results)
    Console.WriteLine(result);

Console.WriteLine($"\nАсинхронно выполнено быстрее на {(syncTime - asyncTime):F3} сек");

static string ProcessData(string dataName)
{
    Thread.Sleep(3000);
    return $"Обработка {dataName} завершена за 3 секунды";
}

static async Task<string> ProcessDataAsync(string dataName)
{
    await Task.Delay(3000);
    return $"Обработка {dataName} завершена за 3 секунды";
}
