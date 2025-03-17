using System;  // Importa funcionalidades básicas do C#
using System.IO;  // Permite manipulação de arquivos

namespace EditorTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();  // Inicia o programa chamando o menu principal
        }

        // Exibe o menu principal e aguarda uma escolha do usuário
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short opcao = short.Parse(Console.ReadLine());  // Lê a opção escolhida pelo usuário

            // Direciona para a função correspondente conforme a escolha
            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;  // Sai do programa
                case 1: Abrir(); break;  // Chama a função para abrir um arquivo
                case 2: Editar(); break;  // Chama a função para criar um novo arquivo
                default: Menu(); break;  // Se for inválido, volta ao menu
            }
        }

        // Função que abre um arquivo e exibe seu conteúdo no console
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();  // Lê o caminho do arquivo digitado pelo usuário

            // Abre o arquivo para leitura
            using (var arquivo = new StreamReader(path))
            {
                string texto = arquivo.ReadToEnd();  // Lê todo o conteúdo do arquivo
                Console.WriteLine(texto);  // Exibe o conteúdo no console
            }

            Console.WriteLine("");
            Console.ReadLine();  // Aguarda o usuário pressionar ENTER
            Menu();  // Retorna ao menu principal
        }

        // Função que permite ao usuário digitar um texto e depois salvá-lo
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo (ESC para sair)");
            Console.WriteLine("--------------------------");

            string texto = "";

            // Lê linha por linha do usuário até que a tecla ESC seja pressionada
            do
            {
                texto += Console.ReadLine();  // Lê a linha digitada
                texto += Environment.NewLine;  // Adiciona uma quebra de linha
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);  // Sai quando ESC for pressionado

            Salvar(texto);  // Chama a função para salvar o texto digitado
        }

        // Função que salva um texto digitado pelo usuário em um arquivo
        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();  // Lê o caminho onde o arquivo será salvo

            // Abre o arquivo para escrita e salva o texto
            using (var arquivo = new StreamWriter(path))
            {
                arquivo.Write(texto);  // Escreve o texto no arquivo
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");  // Confirmação de salvamento
            Console.ReadLine();
            Menu();  // Retorna ao menu principal
        }
    }
}
