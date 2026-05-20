using System;
using System.Collections.Generic;       

class Quarto
{
    private int numero;
    private string nome = "";
    private decimal valordiaria;
    private bool ocupado;

    public int Numero 
    { 
        get { return numero; }
        set { if (value > 0) numero = value; }
    }

    public string Nome 
    { 
        get { return nome; }
        set { nome = value ?? ""; }
    }

    public decimal ValorDiaria 
    { 
        get { return valordiaria; }
        set { if (value >= 0) valordiaria = value; }
    }

    public bool Ocupado 
    { 
        get { return ocupado; }
        set { ocupado = value; }
    }

    public void Reserva(string NomeHospede)
    {
        if (ocupado)
            throw new InvalidOperationException($"O quarto {numero} já está ocupado!");
        
        
        Console.WriteLine($"Quarto {numero} reservado para {NomeHospede}");

        this.Nome = NomeHospede;
        this.Ocupado = true;
        Console.WriteLine($"Reserva realizada para {NomeHospede}");
    }

    public void CancelarReserva()
    {
        if(!Ocupado)
        {
            throw new InvalidOperationException("Não é possível cancelar: o quarto já está livre!");
        }

        Ocupado = false;
        Nome = "";
        Console.WriteLine("Reserva cancelada com sucesso!");
    }
    public decimal CalcularValor(int dias)
    {
        if(dias <= 0)
        {
            throw new ArgumentException("A quantidade de dias tem que ser maior que zero");
        }
        return dias * valordiaria;
    }
    
}
