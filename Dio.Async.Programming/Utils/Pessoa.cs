﻿namespace Dio.Async.Programming;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }

    public void IncrementarIdadeLock()
    {
        lock(this)
        {
            Idade++;
        }

 
    }

    public void IncrementarIdade()
    {
     
       Idade++;
     


    }


    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Idade: {Idade}";
    }
}
