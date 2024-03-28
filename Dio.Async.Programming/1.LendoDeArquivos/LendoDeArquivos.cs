using System.Diagnostics;

namespace Dio.Async.Programming;

internal class LendoDeArquivos
{
    private const string _path = "./1.LendoDeArquivos/arquivo.txt";

    public static void LerArquivo()
    {

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using var reader = File.OpenText(_path);
        var retorno = reader.ReadToEnd();
        Console.WriteLine(retorno);

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");

 
    }

    public static async Task LerArquivoAsync()
    {

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using var reader = File.OpenText(_path);
        var retorno = reader.ReadToEnd();
        await Console.Out.WriteLineAsync(retorno);

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");


    }
}
