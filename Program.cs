﻿using System;

namespace LocadoraVHS
{
    class Program
    {
        static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();
		static ClienteRepositorio repositorioClientes = new ClienteRepositorio();
        static void Main(string[] args)
        {
            
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1F":
						ListarFilmes();
						break;
					case "2F":
						InserirFilme();
						break;
					case "3F":
						AtualizarFilme();
						break;
					case "4F":
						ExcluirFilme();
						break;
					case "5F":
						VisualizarFilme();
						break;

					case "1C":
						ListarClientes();
						break;
					case "2C":
						InserirCliente();
						break;
					case "3C":
						AtualizarCliente();
						break;
					case "4C":
						BanirCliente();
						break;
					case "5C":
						VisualizarCliente();
						break;

					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.ReadLine();
        }


		// METODOS PARA LIDAR COM FILMES
        private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilmes.Exclui(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioFilmes.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			foreach (int i in Enum.GetValues(typeof(FilmeStatus)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FilmeStatus), i));
			}

			Console.Write("Digite a situação do filme entre as opções acima: ");
			int entradaStatus = int.Parse(Console.ReadLine());

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										filmeStatus: (FilmeStatus)entradaStatus);

			repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);
		}
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilmes.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrada.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			foreach (int i in Enum.GetValues(typeof(FilmeStatus)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FilmeStatus), i));
			}

			Console.Write("Digite a situação do filme entre as opções acima: ");
			int entradaStatus = int.Parse(Console.ReadLine());

			Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										filmeStatus: (FilmeStatus)entradaStatus);

			repositorioFilmes.Insere(novoFilme);
		}

		// METODOS PARA LIDAR COM CLIENTES

		private static void BanirCliente()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());

			// Preferia trocar o nome do metodo para banir, mas a Interface me restringe a usar "Exclui"
			repositorioClientes.Exclui(indiceCliente);
		}

		private static void VisualizarCliente()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());

			var cliente = repositorioClientes.RetornaPorId(indiceCliente);

			Console.WriteLine("Nome: {0}", cliente.retornaNome());
			
			var listaDeFilmesComCliente = cliente.ListarFilmesEmPosse(indiceCliente);
			if(listaDeFilmesComCliente.Count > 0)
			{
				Console.WriteLine("Filmes com o cliente: ");
				foreach(int i in listaDeFilmesComCliente)
				{
					Console.WriteLine("- " + "{0}", repositorioFilmes.RetornaPorId(i).retornaTitulo());
				}
			}
			else
			{
				Console.WriteLine("Cliente SEM filmes.");
			}

		}

		private static void ListarClientes()
		{
			Console.WriteLine("Listar clientes");

			var lista = repositorioClientes.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum cliente cadastrado.");
				return;
			}

			foreach (var cliente in lista)
			{
                var excluido = cliente.retornaBanido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", cliente.retornaId(), cliente.retornaNome(), (excluido ? "*BANIDO*" : ""));
			}
		}

		private static void InserirCliente()
		{
			Console.WriteLine("Inserir novo cliente");

			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();

			Cliente novoCliente = new Cliente(id: repositorioClientes.ProximoId(),
										nome: entradaNome);

			repositorioClientes.Insere(novoCliente);
		}

		private static void AtualizarCliente()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();

			Cliente atualizaCliente = new Cliente(id: indiceCliente,
										nome: entradaNome);

			repositorioClientes.Atualiza(indiceCliente, atualizaCliente);
		}

		// INTERFACE COM USUARIO
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo operador de caixa da VHS Filmes!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1F- Listar filmes");
			Console.WriteLine("2F- Inserir novo filme");
			Console.WriteLine("3F- Atualizar filme");
			Console.WriteLine("4F- Excluir filme");
			Console.WriteLine("5F- Visualizar filme");
			Console.WriteLine("--------------------");
			Console.WriteLine("1C- Listar clientes");
			Console.WriteLine("2C- Inserir novo cliente");
			Console.WriteLine("3C- Atualizar cliente");
			Console.WriteLine("4C- Banir cliente");
			Console.WriteLine("5C- Visualizar cliente");
			Console.WriteLine("--------------------");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
