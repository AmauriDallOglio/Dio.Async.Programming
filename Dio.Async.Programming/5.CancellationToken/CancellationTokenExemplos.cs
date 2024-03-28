using System.Diagnostics;

namespace Dio.Async.Programming;
public class CancellationTokenExemplos
{
    public static async Task ExecutarCancellationToken()
    {

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        var cancellation = new CancellationTokenSource();
        cancellation.CancelAfter(2000);
        await OperacaoDemorada(cancellation.Token);


        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");

    }

    private static async Task OperacaoDemorada(CancellationToken token)
    {

 

        await Console.Out.WriteLineAsync("Iniciando a operação de 10s");
        try
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();

                await Console.Out.WriteLineAsync($"Iteração {i}");
                await Task.Delay(1000, token);
            }
        }
        catch (Exception)
        {

            await Console.Out.WriteLineAsync("Operação foi cancelada devido a demora");
        }

 

    }
}