using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Teste de número 6 na lista de testes:\nMultiplicando números com mais de 22 caracteres. \n\nDigite o primeiro número:");
            BigInteger num1 = TestarNumeroGrande();

            Console.WriteLine("Digite o segundo número:");
            BigInteger num2 = TestarNumeroGrande();

            BigInteger resultado = num1 * num2;

            Console.WriteLine($"Resultado da multiplicação: {resultado}");


            Console.WriteLine("\n\nTeste de número 3 na lista de testes: \nCodificando e decodificando arquivos para base64.");

            ConverterParaBase64();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Por favor, entre em contato com o setor do CPD e informe sobre esse erro para abrirmos um bug haha. " + ex.Message);
        }
    }

    static BigInteger TestarNumeroGrande()
    {
        BigInteger numero = 0;
        bool numeroValido = false;

        while (!numeroValido)
        {
            string entrada = Console.ReadLine();
            if (BigInteger.TryParse(entrada, out numero))
            {
                numeroValido = true;
            }
            else
            {
                Console.WriteLine("\nVocê não digitou um número inteiro. \nPor favor, digite um número inteiro:");
            }
        }

        return numero;
    }

    static void ConverterParaBase64()
    {
        bool finalizar = false;
        while (!finalizar)
        {
            Console.WriteLine("\n\nSe voce deseja codigicar um arquivo para base64, " +
            "digite 1. Se você deseja decodificar um arquivo, digite 2.\n\nCaso deseje finalizar a aplicação, digite 0");
            string entrada = Console.ReadLine();
            if (entrada.Equals("1"))
            {
                Console.WriteLine("\n\nInsira o path do arquivo a ser codificado.");
                string codificarArquivo = Console.ReadLine();

                try
                {
                    byte[] arquivo = File.ReadAllBytes(codificarArquivo);
                    string base64String = Convert.ToBase64String(arquivo);

                    Console.WriteLine("\n\nArquivo codificado em Base64:");
                    Console.WriteLine("\n\n" + base64String);
                }
                catch
                {
                    Console.WriteLine("Houve um erro ao tentar efetuar a codificação. Por favor, vamos tentar novamente do inicio.");
                }
            }
            else if (entrada.Equals("2"))
            {
                Console.WriteLine("\n\nInsira o path do arquivo em base64 a ser decodificado:");
                string base64FilePath = Console.ReadLine();

                Console.WriteLine("\n\nInsira o path do arquivo de saída (onde o arquivo decodificado será salvo):");
                string outputFilePath = Console.ReadLine();

                try
                {
                    string base64Content = File.ReadAllText(base64FilePath);
                    byte[] fileBytes = Convert.FromBase64String(base64Content);

                    File.WriteAllBytes(outputFilePath, fileBytes);

                    Console.WriteLine("\n\nArquivo decodificado e salvo com sucesso.");
                }
                catch
                {
                    Console.WriteLine("\n\nHouve um erro ao tentar efetuar a decodificação. Por favor, vamos tentar novamente do inicio.");
                }
            }
            else if (entrada.Equals("0"))
            {
                Console.WriteLine("Obrigado pelo acesso!");
                Thread.Sleep(3000);
                finalizar = true;
            }
            else { Console.WriteLine("\n\nPor favor, digite apenas 1, 2 ou 0."); }
        }
    }
}
