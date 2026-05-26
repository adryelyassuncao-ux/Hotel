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
                if(!string.IsNullOrEmpty(quartoEncontrado.Nome))
                {
                    string nomeCliente = quartoEncontrado.Nome;

                    quartoEncontrado.CancelarReserva();

                    Console.WriteLine($"A reserva do cliente {nomeCliente} para o quarto {numero} foi cancelada com sucesso ");
                }
                else
                {
                    Console.WriteLine($"O quarto {numero} já está livre. Não há reserva para cancelar");
                }

            }
            else
            {
                Console.WriteLine("Quarto não encontrado");
            }
      }
     catch (FormatException)
      {
            Console.WriteLine("Você precisa digitar um número de quarto válido");
      }
      catch (Exception erro)
        {
            Console.WriteLine($"Erro inesperado: {erro.Message}");
        }
    }

    static void CalcularValorEstadia(List<Quarto> lista)
    {
        Console.WriteLine("Digite o número do quarto:");
        int numero = int.Parse(Console.ReadLine()!);

        Quarto quartoEncontrado = BuscarQuarto(numero, lista);

        if(quartoEncontrado != null)
        {
            Console.Write("Digite a quantidade de dias da estadia:");
            int dias = int.Parse(Console.ReadLine()!);

            decimal valorTotal = quartoEncontrado.CalcularValor(dias);

            Console.WriteLine($"Valor da diária: {quartoEncontrado.ValorDiaria:C2} ");
            Console.WriteLine($"O valor total da hospedagem para o quarto {numero} é: {valorTotal:C2}");
        }
        else
        {
            Console.WriteLine("Quarto não encontrado!");
        }
    }
    static void ExibirDadosQuarto(List<Quarto> lista)
    {
        Console.Write("Digite o número do quarto que deseja consultar: ");
        int numero = int.Parse(Console.ReadLine()!);

        Quarto quartoEncontrado = BuscarQuarto(numero, lista);

        if(quartoEncontrado != null)
        {
            Console.WriteLine("Dados do Quarto");

            Console.WriteLine($"Número do Quarto: {quartoEncontrado.Numero}");
            Console.WriteLine($"Valor da Diária: {quartoEncontrado.ValorDiaria:C2}");

            if(string.IsNullOrEmpty(quartoEncontrado.Nome))
            {
                Console.WriteLine("Status Livre");
                Console.WriteLine("Hóspede: (Nenhum hóspede no momento)");
            }
            else
            {
                Console.WriteLine("Status: Ocupado");

                Console.WriteLine($"Hóspede: {quartoEncontrado.Nome}");
            }
            Console.WriteLine("-----------------------");
        }
            else
            {
                Console.WriteLine("Quarto não encontrado!");
            }
       
    }

    static void MudarValor()
    {
    Console.WriteLine("Alterar valor");
    Console.WriteLine($"1- Economico (Atual: {precoeconomico:C2})");
    Console.WriteLine($"2- Executivo (Atual: {precoexecutivo:C2})");
    Console.WriteLine($"3- Master (Atual: {precomaster:C2}");
    Console.WriteLine("Escolha qual categoria alterar 1-3:");

    int opcao = int.Parse(Console.ReadLine()!);

    if(opcao >=1 && opcao <= 3)
        {
            Console.Write("Digite o novo valor da diária: R$");
            decimal novoValor = decimal.Parse(Console.ReadLine()!);

            if(opcao == 1)
            {
                precoeconomico = novoValor;
                Console.WriteLine($"Categoria economica alterada para o valor {precoeconomico:C2}");
            }
            else if(opcao == 2)
            {
                precoexecutivo = novoValor;
                Console.WriteLine($"Categoria Executivo alterada para {precoexecutivo:C2}");
            }
            else if (opcao == 3)
            {
                precomaster = novoValor;
                Console.WriteLine($"Categoria Master alterada para {precomaster:C2}");
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

    }
    static void Main()
    {
        
      List<Quarto> ListadeQuatos = new List<Quarto>();
      int opcao = 0;
        while(opcao != 7)
        {
        Console.WriteLine("_Menu_");
        Console.WriteLine("1- Criar quarto");
        Console.WriteLine("2- Reservar quarto");
        Console.WriteLine("3- Cancelar reserva");
        Console.WriteLine("4- Calcular valor da estadia");
        Console.WriteLine("5- Exibir dados do quarto");
        Console.WriteLine("6- Mudar valor");
        Console.WriteLine("7- Sair");
        
        opcao = int.Parse(Console.ReadLine()!);
        
        switch (opcao)
        {
            case 1:
            CriarQuarto(ListadeQuatos);
            break;

            case 2:
            Reserva(ListadeQuatos);
            break;

            case 3:
            CancelarReserva(ListadeQuatos);
            break;

            case 4:
            CalcularValorEstadia(ListadeQuatos);
            break;

            case 5:
            ExibirDadosQuarto(ListadeQuatos);
            break;

            case 6:
            MudarValor();
            break; 

            case 7:
            Console.Clear();
            Console.WriteLine("Sistema de hotel encerrado");
            Console.WriteLine("Pressione qualquer tecla para fechar a janela");
            Console.ReadKey();
            Environment.Exit(0);
            break;

        }
      }

    }
}