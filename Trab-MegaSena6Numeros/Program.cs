// faça um programa que sorteie os 6 numeros da mega sena e grave-os em um vetor ordenado
using System.Runtime.CompilerServices;

while (true)
{

    int aux, opcao, numero, size, x, pos, sizerandom, random;
   
    opcao = 0;
    numero = 0;
    size = 6;
    x = 1;
    pos = 0;
    sizerandom = 60;
    random = 0;

    int[] megasena = new int[60];
    int[] megausuario = new int[size];
    int[] megasena_ok = new int[size];
    int[] megasena_unique = new int[size];

    // USO VETOR "MEGASENA" COM 60 POSICOES
    for (int i = 0; i < sizerandom; i++)
    {
        megasena[i] = i+1;
    }

    for (int i = 0; i < 6; i++)
    {
        random = new Random().Next(1, 60);
        megasena_unique[i] = megasena[random];
    }

    x = 0;
    numero = 0;
    Console.WriteLine("Quer tentar a sorte grande? Digite 0.");
    opcao = int.Parse(Console.ReadLine());
    if (opcao == 0)
    {
        for (int i = 0; i < 6; i++)
        {
            while (numero <= 0 || numero > 60)
            {
                Console.WriteLine($"Informe o {i + 1}o número! Deve ser entre 1 e 60!");
                numero = int.Parse(Console.ReadLine());
            }
            while (x < 6)
            {
                if (numero == megausuario[x])
                {
                    Console.WriteLine($"Número já informado! Informe o {i + 1}o número!");
                    numero = int.Parse(Console.ReadLine());

                    while (numero <= 0 || numero > 60)
                    {
                        Console.WriteLine($"Informe o {i + 1}o número! Deve ser entre 1 e 60!");
                        numero = int.Parse(Console.ReadLine());
                    }

                    x = 0;
                }
                else
                {
                    x++;
                }
            }
            x = 0;
            megausuario[i] = numero;
            numero = 0;
        }


        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (megausuario[i] > megausuario[j])
                {
                    aux = megausuario[i];
                    megausuario[i] = megausuario[j];
                    megausuario[j] = aux;
                }
            }
        }

        // TUDO QUE ERA megasena_ord VIROU megasena_unique

        Console.WriteLine("\n******** SEUS NUMEROS: ********");
        for (int i = 0; i < 6; i++)
        {
            Console.Write(megausuario[i] + " ");
        }
        Console.WriteLine("\n******** SORTEIO DA MEGASENA ********");
        for (int i = 0; i < 6; i++)
        {
            Console.Write(megasena_unique[i] + " ");
        }

        int casa = 0;
        pos = 0;
        while (casa < size)
        {
            for (int i = 0; i < size; i++)
            {
                if (megausuario[casa] == megasena_unique[i])
                {
                    megasena_ok[pos] = megausuario[casa];
                    pos++;
                }
            }
            casa++;
        }
        Console.WriteLine("\n******** VOCE ACERTOU OS NUMEROS ********");
        for (int i = 0; i < 6; i++)
        {
            if (megasena_ok[i] > 0)
            {
                Console.Write(megasena_ok[i] + " ");
            }
        }

    }
    else
    {
        Console.WriteLine("Que pena que não quis participar =(. Em todo caso:");
        Console.WriteLine("\n******** SORTEIO DA MEGASENA!!! ********");
        for (int i = 0; i < 6; i++)
        {
            Console.Write(megasena_unique[i] + " ");
        }
    }

    Console.ReadKey();
}