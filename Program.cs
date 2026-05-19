using System;

class Program
{
    static decimal precoeconomico= 0;
    static decimal precoexecutivo= 0;
    static decimal precomaster= 0;
  
  
    static void CriarQuarto (List <Quarto> lista)
    
        {
            if(precoeconomico == 0 || precoexecutivo == 0 || precomaster == 0)
            {
                throw new InvalidOperationException("Os preços ainda não foram adicionados, para adicionar escolha a opção 6 do menu ");
            }

            try
            {
            Console.WriteLine("Escolha a categoria do quarto");
            Console.WriteLine($"1- Quarto Econômico: Preço R${precoeconomico}");
            Console.WriteLine($"2- Quarto Executivo: Preço R${precoexecutivo} ");
            Console.WriteLine($"3- Quarto Master: Preço R${precomaster}");
            int tipo = int.Parse(Console.ReadLine()!);

            decimal valordefinido = 0;
            
            switch (tipo)
                {
                    case 1: valordefinido = precoeconomico; break;
                    case 2: valordefinido = precoexecutivo; break;
                    case 3: valordefinido = precomaster; break;
                    default: throw new ArgumentException("Opção invalida! digite um numero de 1 a 3");
                }

                Quarto novoQuarto = new Quarto();
                novoQuarto.ValorDiaria = valordefinido;
                lista.Add(novoQuarto);

                Console.WriteLine($"Quarto {novoQuarto.Numero} criado com sucesso! ");
            }

            catch (FormatException)
            {
                Console.WriteLine("Você precisa digitar um número inteiro válido!");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"{erro.Message}");
            }
        }
        


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

    static void Reserva(List<Quarto> lista)
    {
     try
        {
         Console.Write("Digite o número do quarto:");
         int numero = int.Parse(Console.ReadLine()!);

         Quarto quartoEncontrado = BuscarQuarto(numero, lista);

          if (quartoEncontrado != null)
         {
           Console.WriteLine("Digite o nome do hóspede:");
           string NomeHospede = Console.ReadLine()!;

           quartoEncontrado.Reserva(NomeHospede);

           Console.WriteLine($"Quarto {numero} reservado com sucesso {NomeHospede} ");
         }
         else
         {
            Console.WriteLine("Quarto não encontrado");
         } 
       }
        catch (FormatException)
        {
            Console.WriteLine("O número do quarto deve ser um valor numérico inteiro.");
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Erro ao realizar reserva: {erro.Message}");
        }
    }

    static void CancelarReserva(List<Quarto> lista)
    {
     try
      {
        Console.WriteLine("Qual o número do quarto?");
        int numero = int.Parse(Console.ReadLine()!); 

        Quarto quartoEncontrado = BuscarQuarto(numero, lista);

        if(quartoEncontrado != null)
            {
                
            }   
      }
     catch
      {
            
      }
    }

    static void Main()
    {
        
      List<Quarto> ListadeQuatos = new List<Quarto>();

        Console.WriteLine("_Menu_");
        Console.WriteLine("1- Criar quarto");
        Console.WriteLine("2- Reservar quarto");
        Console.WriteLine("3- Cancelar reserva");
        Console.WriteLine("4- Calcular valor da estadia");
        Console.WriteLine("5- Exibir dados do quarto");
        Console.WriteLine("6- Mudar valor");
        Console.WriteLine("7- Sair");

        int numero = 7;
        switch (numero)
        {
            case 1:
          CriarQuarto(ListadeQuatos);
            break;

            case 2:
            Reserva(ListadeQuatos);
            break;

            case 3:

        }


    }
}