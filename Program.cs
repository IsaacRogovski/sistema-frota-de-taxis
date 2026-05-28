using System;

namespace taxis
{

    class Program
    {
        public static void Main(string[] args)
        {

            float[] valoresCarros = new float[5];

            bool sistema = true;
            string? opcao;

            while (sistema)
            {
                Console.Clear();
                Console.WriteLine("+───Controle de frota───+\n");
                Console.WriteLine("┌ 1 - Lançar corrida.");
                Console.WriteLine("├ 2 - Mostrar faturamento.");
                Console.WriteLine("├ 3 - Informar carro com maior faturamento.");
                Console.WriteLine("├ 4 - Informar carro com menor faturamento.");
                Console.WriteLine("├ 5 - Zerar o faturamento.");
                Console.WriteLine("└ 0 - SAIR.");
                Console.Write("\nInsira a opção que deseja: ");
                opcao = (Console.ReadLine() ?? "").ToLower();

                switch (opcao)
                {
                    case "1":

                        Console.Clear();
                        int numeroCarro;
                        float valorCorrida;
                        while (true)
                        {
                            numeroCarro = FuncoesAuxiliares.lerNumeroInteiro("Insira o numero do carro: ");
                            if (numeroCarro <= 0 || numeroCarro > valoresCarros.Length)
                            {
                                Console.WriteLine("\nInsira um numero de carro valido! (Entre 1 e {0}).\n",valoresCarros.Length);
                            }
                            else
                            {
                                numeroCarro--;
                                break;
                            }
                        }
                        Console.WriteLine("");
                        while (true)
                        {
                            valorCorrida = FuncoesAuxiliares.lerNumeroFlutuante("Insira o valor da corrida: ");
                            if (valorCorrida < 0)
                            {
                                Console.WriteLine("\nInsira um valor valido!\n");
                            }
                            else
                            {
                                valoresCarros[numeroCarro] += valorCorrida;
                                Console.WriteLine("Corrida no valor de {0} lancada!", valorCorrida.ToString("C"));
                                break;
                            }
                        }

                        Console.ReadKey();
                        break;
                    case "2":

                        Console.Clear();

                        Console.WriteLine("┌──────┬────────────────┐");
                        Console.WriteLine("│ Taxi │       R$       │");
                        Console.WriteLine("├──────┼────────────────┤");
                        for (int i = 0; i < valoresCarros.Length; i++)
                        {
                            Console.WriteLine("│  {0,-3} │{1,15} │",i+1,valoresCarros[i].ToString("C"));
                            if (i != valoresCarros.Length - 1)
                            {
                                Console.WriteLine("├──────┼────────────────┤");
                            }
                            else
                            {
                                Console.WriteLine("└──────┴────────────────┘");
                            }
                            
                        }
                        Console.ReadKey();

                        break;
                    case "3":
                        int maiorValor = 0;
                        for(int i = 1; i<valoresCarros.Length; i++)
                        {
                            if (valoresCarros[maiorValor] < valoresCarros[i])
                            {
                                maiorValor = i;
                            }
                        }
                        Console.WriteLine("\nO taxi que mais faturou foi o {0}, com {1}",maiorValor+1,valoresCarros[maiorValor].ToString("C"));
                        Console.ReadKey();
                        break;
                    case "4":
                        int menorValor = 0;
                        for(int i = 1; i<valoresCarros.Length; i++)
                        {
                            if (valoresCarros[menorValor] > valoresCarros[i])
                            {
                                menorValor = i;
                            }
                        }
                        Console.WriteLine("\nO taxi que menos faturou foi o {0}, com {1}",menorValor+1,valoresCarros[menorValor].ToString("C"));
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.Write("Você tem certeza que deseja zerar o faturamento? (S/N): ");
                        if(FuncoesAuxiliares.simOuNao() == true)
                        {
                            for(int i = 0; i < valoresCarros.Length; i++)
                            {
                                valoresCarros[i] = 0;
                            }
                            Console.WriteLine("Dados zerados!");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Progama finalizado!\n");
                        sistema = false;
                        break;
                }
            }
        }
        class FuncoesAuxiliares
        {
            public static int lerNumeroInteiro(string enunciado)
            {
                int valor;
                Console.Write(enunciado);
                while (!int.TryParse(Console.ReadLine(), out valor))
                {

                    Console.WriteLine("Insira um valor valido!");
                    Console.Write(enunciado);
                }

                return valor;
            }

            public static float lerNumeroFlutuante(string enunciado)
            {
                float valor;
                Console.Write(enunciado);
                while (!float.TryParse(Console.ReadLine(), out valor))
                {

                    Console.WriteLine("Insira um valor valido!");
                    Console.Write(enunciado);
                }

                return valor;
            }

            public static bool simOuNao()
            {

                string opcaoSelecionadaSimOuNao = (Console.ReadLine() ?? "").ToLower();
                return opcaoSelecionadaSimOuNao == "s" ? true : false;
            }
        }
    }
}