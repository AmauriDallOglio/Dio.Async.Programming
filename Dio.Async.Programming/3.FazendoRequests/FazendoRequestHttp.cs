using System.Diagnostics;

namespace Dio.Async.Programming;

internal class FazendoRequestHttp
{
    private const string _requestUri = "http://localhost:5223/api/controllersimples";

    public static async Task<string> GetRequest()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using var httpClient = new HttpClient();
        var resposta = await httpClient.GetAsync(_requestUri);
        return await resposta.Content.ReadAsStringAsync();


        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");
    }

    public static async Task GetRequestSequential()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        using var httpClient = new HttpClient();
        for (int i = 0; i < 5; i++)
        {
            var resposta = await httpClient.GetAsync(_requestUri);
            var resultado = await resposta.Content.ReadAsStringAsync();
        }


        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");
    }

    public static async Task GetRequestParallel()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        using var httpClient = new HttpClient();
        var talks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            talks.Add(httpClient.GetAsync(_requestUri));
        }
        await Task.WhenAll(talks);

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");
    }
}
