using System;

public class NoDaLista
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    public int Quantidade { get; set; }
    public NoDaLista Prox { get; set; }

    public NoDaLista(string titulo, string autor, int ano, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
        Quantidade = quantidade;
        Prox = null;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NoDaLista lista = null;

        lista = InserirLivro(lista, "Dom Casmurro", "Machado de Assis", 1899, 5);
        lista = InserirLivro(lista, "O Cortiço", "Aluísio Azevedo", 1890, 3);
        lista = InserirLivro(lista, "Capitães da Areia", "Jorge Amado", 1937, 8);
        lista = InserirLivro(lista, "Grande Sertão: Veredas", "João Guimarães Rosa", 1956, 2);
        lista = InserirLivro(lista, "A Hora da Estrela", "Clarice Lispector", 1977, 4);
        lista = InserirLivro(lista, "Vidas Secas", "Graciliano Ramos", 1938, 6);
        lista = InserirLivro(lista, "Memórias Póstumas de Brás Cubas", "Machado de Assis", 1881, 7);

        int opcao, ano;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Imprimir Todos");
            Console.WriteLine("2. Buscar por Ano (Iterativo)");
            Console.WriteLine("3. Buscar por Ano (Recursivo)");
            Console.WriteLine("4. Ver Quantidade Total de Livros");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

            switch (opcao)
            {
                case 1:
                    ImprimirTodos(lista);
                    break;
                case 2:
                    Console.Write("Digite o ano para busca: ");
                    int.TryParse(Console.ReadLine(), out ano);
                    BuscaAno(lista, ano);
                    break;
                case 3:
                    Console.Write("Digite o ano para busca recursiva: ");
                    int.TryParse(Console.ReadLine(), out ano);
                    Console.WriteLine($"\n--- Busca (Recursiva) Ano: {ano} ---");
                    LivrosAnoRec(lista, ano);
                    break;
                case 4:
                    Console.WriteLine($"Quantidade total de livros no estoque: {VerQuantidadeLivros(lista)}");
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    public static NoDaLista InserirLivro(NoDaLista head, string titulo, string autor, int ano, int quantidade)
    {
        NoDaLista novo = new NoDaLista(titulo, autor, ano, quantidade);

        if (head == null || novo.Ano < head.Ano)
        {
            novo.Prox = head;
            return novo;
        }

        NoDaLista atual = head;
        while (atual.Prox != null && atual.Prox.Ano < novo.Ano)
        {
            atual = atual.Prox;
        }

        novo.Prox = atual.Prox;
        atual.Prox = novo;

        return head;
    }

    public static void ImprimirTodos(NoDaLista head)
    {
        NoDaLista atual = head;
        if (atual == null)
        {
            Console.WriteLine("Lista vazia.");
            return;
        }

        Console.WriteLine("\n--- Lista de Livros ---");
        while (atual != null)
        {
            Console.WriteLine($"Título: {atual.Titulo} | Autor: {atual.Autor} | Ano: {atual.Ano} | Qtd: {atual.Quantidade}");
            atual = atual.Prox;
        }
    }

    public static void BuscaAno(NoDaLista head, int anoBusca)
    {
        NoDaLista atual = head;
        bool encontrou = false;

        Console.WriteLine($"\n--- Busca (Iterativa) Ano: {anoBusca} ---");
        while (atual != null)
        {
            if (atual.Ano == anoBusca)
            {
                Console.WriteLine($"Título: {atual.Titulo} | Autor: {atual.Autor} | Qtd: {atual.Quantidade}");
                encontrou = true;
            }

            if (atual.Ano > anoBusca)
            {
                break;
            }
            atual = atual.Prox;
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum livro encontrado para este ano.");
        }
    }

    public static void LivrosAnoRec(NoDaLista no, int anoBusca)
    {
        if (no == null)
        {
            return;
        }

        if (no.Ano > anoBusca)
        {
            return;
        }

        if (no.Ano == anoBusca)
        {
            Console.WriteLine($"Título: {no.Titulo} | Autor: {no.Autor} | Qtd: {no.Quantidade}");
        }

        LivrosAnoRec(no.Prox, anoBusca);
    }

    public static int VerQuantidadeLivros(NoDaLista head)
    {
        NoDaLista atual = head;
        int somaTotal = 0;

        while (atual != null)
        {
            somaTotal += atual.Quantidade;
            atual = atual.Prox;
        }

        return somaTotal;
    }
}
