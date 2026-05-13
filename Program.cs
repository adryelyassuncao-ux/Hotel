using System;

class Program
{
    static void Main()
    {
        List<Quarto> ListadeQuatos = new List<Quarto>();

        Console.WriteLine("_Menu_");
        Console.WriteLine("1- Criar quarto");
        Console.WriteLine("2- Reservar quarto");
        Console.WriteLine("3- Cancelar reserva");
        Console.WriteLine("4- Calcular valor da estadia");
        Console.WriteLine("5- Exibir dados do quarto");
        Console.WriteLine("6- Sair");


        static Quarto BuscarQuarto (int numeroquarto, List<Quarto> lista)
        {
        foreach(var item in lista)
            {
                if(item.Numero == numeroquarto)
                {
                    return item;
                }
            }
            return null;
        }

        int numero = 6;
        switch (numero)
        {
            case 1:

        }


    }
}