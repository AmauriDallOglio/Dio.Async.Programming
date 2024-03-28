using System.Diagnostics;

namespace Dio.Async.Programming;

internal class Cozinha
{
    public void FazerComida()
    {

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        FritarOvo();
        CozinharArroz();

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");

    }

    private void FritarOvo()
    {
        Console.WriteLine("Fritando ovo: 5s");
        Thread.Sleep(5000);
        Console.WriteLine("Ovo frito");
    }

    private void CozinharArroz()
    {
        Console.WriteLine("Cozinhando arroz: 10s");
        Thread.Sleep(10000);
        Console.WriteLine("Arroz cozido");
    }

    public async Task FazerComidaAsync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        //await FritarOvoAsync();
        //await CozinharArrozAsync();
        await Task.WhenAll(FritarOvoAsync(), CozinharArrozAsync());

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");
    }

    private async Task FritarOvoAsync()
    {
        await Console.Out.WriteLineAsync("Fritando o ovo");
        await Task.Delay(5000);
        await Console.Out.WriteLineAsync("Ovo frito");
    }

    private async Task CozinharArrozAsync()
    {
        await Console.Out.WriteLineAsync("Cozinhando o arroz");
        await Task.Delay(10000);
        await Console.Out.WriteLineAsync("Arroz cozido");

    }

}
