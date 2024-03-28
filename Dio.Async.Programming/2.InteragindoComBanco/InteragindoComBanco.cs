using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dio.Async.Programming;

public class InteragindoComBanco
{
    private AppDbContext _appDbContext;
    public InteragindoComBanco()
    {
        _appDbContext = new AppDbContext();
        _appDbContext.Database.EnsureCreated();
        _appDbContext.Seed();
    }

    public void LerDoBanco()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        var pessoas = _appDbContext.Pessoas.ToList();
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine(pessoa);
        }

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");

    }

    public async Task LerDoBancoAsync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        var pessoas = await _appDbContext.Pessoas.ToListAsync();
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine(pessoa);
        }

        stopwatch.Stop();
        long tempoDecorridoMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tempo total: {tempoDecorridoMs} ms");


    }
}

