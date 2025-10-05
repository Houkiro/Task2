Console.WriteLine($"Начало синхронных задач {DateTime.Now}");
Console.WriteLine(ProcessData("Файл 1"));
Console.WriteLine(ProcessData("Файл 2"));
Console.WriteLine(ProcessData("Файл 3"));
Console.WriteLine($"Завершение синхронных задач {DateTime.Now}\n");

Console.WriteLine($"Начало асинхронных задач {DateTime.Now}");
string[] results = await Task.WhenAll(
    ProcessDataAsync("Асинхронно файл 1"),
    ProcessDataAsync("Асинхронно файл 2"),
    ProcessDataAsync("Асинхронно файл 3")
);
Console.WriteLine($"Завершение асинхронных задач {DateTime.Now}\n");

foreach (string result in results)
    Console.WriteLine(result);

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
