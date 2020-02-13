using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioPc = System.Environment.UserName;

            Console.WriteLine($"Seja bem vindo {usuarioPc}", Console.ForegroundColor = ConsoleColor.White);

            SetInitial();
        }

        static void SetInitial()
        {
            Console.WriteLine("------------------------\n", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine("Opções:");
            Console.WriteLine("\t1 - Adição");
            Console.WriteLine("\t2 - Subtração");
            Console.WriteLine("\t3 - Multiplicação");
            Console.WriteLine("\t4 - Divisão");
            Console.WriteLine("\t5 - Adição de uma lista de números");
            Console.WriteLine("\t6 - Calcular média de uma lista de números");
            Console.WriteLine("\t7 - Calcular os numeros pares da lista");
            Console.WriteLine("\t8 - Salvando no dicionario");
            Console.WriteLine("\n------------------------\n");

            Console.WriteLine("Qual operação deseja?: ");
            int operacao = Convert.ToInt32(Console.ReadLine());

            if (operacao < 9 && operacao > 0)
                GetCalculadora(operacao);
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine($"A opção escolhida está invalida: {operacao}");
                Console.WriteLine("\n");
                SetInitial();
            }
        }

        static void GetCalculadora(int operacao)
        {
            var valor01 = 0.0;
            var valor02 = 0.0;
            var total = 0.0;
            List<double> listaValores = new List<double>();
            List<int> listaNumerosPares = new List<int>();
            var operacaoMatematica = string.Empty;

            if (operacao == 5 || operacao == 6 || operacao == 7)
            {
                Console.Write("Digite uma lista de números ou Esc para sair ");

                Console.WriteLine("\n");
                do
                {
                    Console.Clear();
                    Console.Write("Digite um numero: ", Console.ForegroundColor = ConsoleColor.White);
                    var testeNumber = Console.ReadLine();

                    //Verificador se está passando valor vavidos.
                    bool verificador = GetNumeros(testeNumber);

                    if (verificador)
                    {
                        double vetor = double.Parse(testeNumber);

                        listaValores.Add(vetor);

                        //Valores que foi digitado anteriormente
                        GetValores(listaValores);

                        Console.Write("\n Pressione qualquer tecla  para continuar ou Esc para sair");
                    }
                    else
                    {
                        Console.Write("O valor digitado esta invalido, digite um numero valido", Console.ForegroundColor = ConsoleColor.Red);
                        Console.WriteLine("\n");
                        Console.Write("Digite Enter  para continuar  ou Esc para sair ", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.WriteLine("\n");
                    }

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                {

                    if (operacao == 5)
                    {
                        //Método somar lista de numeros
                        total = GetSoma(listaValores);

                        //Formatação de numeros
                        string.Format("{0:0,0.00}", total);

                        Console.WriteLine("\n");
                        Console.WriteLine($"O total das samos dos números :{total}", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.WriteLine("\n");
                    }

                    if (operacao == 6)
                    {
                        //CalcaularMedia
                        var valorMedia = GetCalculaMedia(listaValores);

                        Console.WriteLine("\n");
                        Console.WriteLine($"A media desses valores é :{valorMedia}", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.WriteLine("\n");
                    }

                    if (operacao == 7)
                    {
                        //Método somar numeros pares
                        var valorPares = GetCalculaPares(listaValores);

                        Console.WriteLine("\n");

                        Console.WriteLine("Os numeros digitados até agora são :");
                        //Formatação de numeros
                        string.Format("{0:0,0.00}", valorPares);
                        Console.WriteLine($"A soma dos números pares:{valorPares}", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.WriteLine("\n");
                    }

                    //Sair da aplicação.
                    Ext();
                }
            }

            //Gerando dicionario
            if (operacao == 8)
            {
                //Método para criar lista Dicionario.
                GetDicionario();
                Console.WriteLine("\n");
                Ext();
            }

            try
            {
                //Expressão matematicas.
                Console.WriteLine("\n");
                Console.WriteLine("Digite o primeiro número é pressione enter");
                valor01 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite o segundo número é pressione enter");
                valor02 = Convert.ToDouble(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"O valor informado e invalido: {valor01} + {valor02}", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine("\n");
                Console.Write("Pressione qualquer tecla para execultar outro processo ou ESC para sair");
                Console.WriteLine("\n");
                while (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    SetInitial();
                    Console.Clear();
                }

                Console.WriteLine("\n");
                Console.WriteLine("Obrigado por ultilizar nossa calculadora");
                Console.WriteLine("\n");

                //Fechando a aplicação
                Ext();
            }

            //Adição
            if (operacao == 1)
            {
                total = GetSoma(valor01, valor02);
                operacaoMatematica = "+";
            }

            //Subtração
            if (operacao == 2)
            {
                total = GetSubtração(valor01, valor02);
                operacaoMatematica = "-";
            }

            //Multiplicação
            if (operacao == 3)
            {
                total = GetMultiplicação(valor01, valor02);
                operacaoMatematica = "*";
            }

            //Divisão
            if (operacao == 4)
            {
                total = GetDivição(valor01, valor02);
                operacaoMatematica = "/";
            }
                      

            Console.WriteLine("\n");

            //Formatação de numeros
            string.Format("{0:0,0.00}", total);
            Console.WriteLine($"O total do calculo é: {valor01} {operacaoMatematica} {valor02} = {total}", Console.ForegroundColor = ConsoleColor.Blue);
            Console.WriteLine("\n");

            //Fechando aplicação
            Ext();

            static void Ext()
            {
                Console.Write("Pressione qualquer tecla para execultar outra operação ou ESC para sair");
                while (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Obrigado por ultilizar nossa calculadora");
                    Console.WriteLine("\n");

                    TimeSpan interval = new TimeSpan(2);
                    Console.WriteLine(interval.ToString());

                    //Fechando a aplicação
                    Environment.Exit(0);
                }

                //Voltar para as operações
                Console.Clear();
                Console.WriteLine("\n");
                SetInitial();
            }
        }

        //Método de adição
        static double GetSoma(double valor01, double valor02)
        {
            return valor01 + valor02;
        }

        //Método de Subtração
        static double GetSubtração(double valor01, double valor02)
        {
            return valor01 - valor02;
        }

        //Método de Multiplicação
        static double GetMultiplicação(double valor01, double valor02)
        {
            return valor01 * valor02;
        }

        //Método de Divição
        static double GetDivição(double valor01, double valor02)
        {
            return valor01 / valor02;
        }

        //Método somar lista
        static double GetSoma(List<double> listaDeValor)
        {
            var total = listaDeValor.Sum();

            return total;
        }

        //Método calcular media
        static double GetCalculaMedia(List<double> listaDeValor)
        {
            var total = listaDeValor.Sum();
            total = total / listaDeValor.Count();
            return total;
        }

        //Método calcular valores pares
        static double GetCalculaPares(List<double> listaNumerosPares)
        {
            var query = from p in listaNumerosPares
                        where p % 2 == 0
                        select p;

            var total = listaNumerosPares.Sum();
            return total;
        }

        static void GetValores(List<double> listaValores)
        {
            double[] array = listaValores.ToArray();

            Console.Write("\nValores digitados anteriormente:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }

            Console.WriteLine();
        }

        static void GetDicionario()
        {
            double[] array = {10,20,2,5,12};

            SortedDictionary<string, double> dicionario = new SortedDictionary<string, double>();
            dicionario.Add("José", GetSoma(10, 2));
            dicionario.Add("Adailtom", GetDivição(10, 2));
            dicionario.Add("Raimundo", GetMultiplicação(10, 2));
            dicionario.Add("Antonio", GetSubtração(10, 2));
            dicionario.Add("Joaquim", GetSubtração(10, 2));
            dicionario.Add("Paula", GetDivição(10, 2));
            Console.WriteLine("\n");
            Console.WriteLine("Informa seu nome complemto e pressione Enter");
            var nome = Console.ReadLine();
            Console.WriteLine("\n");
            dicionario.Add($"{nome}", GetSoma(array.ToList()));

            // Imprime o dicionario em ordem alfabética
            foreach (KeyValuePair<string, double> p in dicionario)
            {
                Console.WriteLine("{0} = {1}", p.Key, p.Value, Console.ForegroundColor = ConsoleColor.Green);
            }

            Console.ReadKey();

        }

        //Verificação de valores digitos são numerico.
        private static bool GetNumeros(string numero)
        {
            bool numerico;

            try
            {
                var valor = (Convert.ToDouble(numero));
                numerico = true;
            }
            catch (Exception)
            {
                numerico = false;
            }

            return numerico;
        }
    }
}