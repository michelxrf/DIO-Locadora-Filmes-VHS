using System;

namespace LocadoraVHS
{
    class Program
    {
        static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();
		static ClienteRepositorio repositorioClientes = new ClienteRepositorio();

        static void Main(string[] args)
        {
            
			repositorioFilmes.LerDeArquivo();
			repositorioClientes.LerDeArquivo();

			string opcaoUsuario = ObterOpcaoUsuario();

			while (true)
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

					case "A":
						Alugar();
						break;
					case "D":
						Devolver();
						break;

					case "X":
						System.Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Comando inválido. Consulte a tabela acima para saber os comandos válidos.");
						
						Console.WriteLine();
						Console.WriteLine("Pressione uma tecla para continuar");
						Console.ReadKey();
						Console.Clear();	
						break;
				}

				repositorioClientes.GravarEmArquivo();
				repositorioFilmes.GravarEmArquivo();

				opcaoUsuario = ObterOpcaoUsuario();
			}

        }


		// METODOS PARA LIDAR COM FILMES
        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			Console.Clear();

			var filme = repositorioFilmes.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
			Console.WriteLine();
			Console.WriteLine("Pressione uma tecla para continuar");
			Console.ReadKey();
			Console.Clear();		
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			Console.Clear();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();
			Console.Clear();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();
			Console.Clear();

			foreach (int i in Enum.GetValues(typeof(FilmeStatus)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FilmeStatus), i));
			}

			Console.Write("Digite a situação do filme entre as opções acima: ");
			int entradaStatus = int.Parse(Console.ReadLine());
			Console.Clear();

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
			var lista = repositorioFilmes.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrada.");
			}
			else
			{
				foreach (var filme in lista)
				{  
					Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
				}
			}

			Console.WriteLine();
			Console.WriteLine("Pressione uma tecla para continuar");
			Console.ReadKey();
			Console.Clear();	
			
		}

        private static void InserirFilme()
		{
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();
			Console.Clear();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();
			Console.Clear();

			for (int i = 0; i < 3 ; i++)
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FilmeStatus), i));
			}

			Console.Write("Digite a situação do filme entre as opções acima: ");
			int entradaStatus = int.Parse(Console.ReadLine());
			Console.Clear();

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
			Console.Clear();

			// Preferia trocar o nome do metodo para banir, mas a Interface me restringe a usar "Exclui"
			repositorioClientes.Banir(indiceCliente);
		}

		private static void VisualizarCliente()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());
			Console.Clear();

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

			Console.WriteLine();
			Console.WriteLine("Pressione uma tecla para continuar");
			Console.ReadKey();
			Console.Clear();	

		}

		private static void ListarClientes()
		{
			var lista = repositorioClientes.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum cliente cadastrado.");
			}
			else
			{
				foreach (var cliente in lista)
				{
					var excluido = cliente.retornaBanido();
					
					Console.WriteLine("#ID {0}: - {1} {2}", cliente.retornaId(), cliente.retornaNome(), (excluido ? "*BANIDO*" : ""));
				}
			}

			Console.WriteLine();
			Console.WriteLine("Pressione uma tecla para continuar");
			Console.ReadKey();
			Console.Clear();	

		}

		private static void InserirCliente()
		{
			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();
			Console.Clear();

			Cliente novoCliente = new Cliente(id: repositorioClientes.ProximoId(),
										nome: entradaNome);

			repositorioClientes.Insere(novoCliente);
		}

		private static void AtualizarCliente()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();
			Console.Clear();

			Cliente atualizaCliente = new Cliente(id: indiceCliente,
										nome: entradaNome);

			repositorioClientes.Atualiza(indiceCliente, atualizaCliente);
		}

		// ALUGUEIS E DEVOLUÇÕES
		private static void Alugar()
		{
			Console.Write("Digite o id do cliente: ");
			int indiceCliente = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			Console.Clear();

			if(repositorioFilmes.RetornaPorId(indiceFilme).RetornaStatus() == FilmeStatus.Disponivel)
			{
				repositorioFilmes.RetornaPorId(indiceFilme).Alugar(indiceCliente);
				repositorioClientes.RetornaPorId(indiceCliente).Alugar(indiceFilme);
			}
			else
			{
				Console.WriteLine($"Impossível alugar, o filme encontra-se {repositorioFilmes.RetornaPorId(indiceFilme).RetornaStatus()}");
			}
			
			Console.WriteLine();
			Console.WriteLine("Pressione uma tecla para continuar");
			Console.ReadKey();
			Console.Clear();		
		}

		public static void Devolver()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			Console.Clear();

			if((repositorioFilmes.RetornaPorId(indiceFilme).RetornaStatus() == FilmeStatus.Alugado))
			{
				int indiceCliente = repositorioFilmes.RetornaPorId(indiceFilme).RetornaTomador();
				repositorioClientes.RetornaPorId(indiceCliente).Devolver(indiceFilme);
				// Aqui é bom colocar uma verificação, caso o cadastro do cliente ou do filme tenha sido
				//manualmente alterado pode causar um crash aqui

				repositorioFilmes.RetornaPorId(indiceFilme).Devolver();

			}
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
			Console.WriteLine("4F- Visualizar filme");
			Console.WriteLine("--------------------");
			Console.WriteLine("1C- Listar clientes");
			Console.WriteLine("2C- Inserir novo cliente");
			Console.WriteLine("3C- Atualizar cliente");
			Console.WriteLine("4C- Banir cliente");
			Console.WriteLine("5C- Visualizar cliente");
			Console.WriteLine("--------------------");
			Console.WriteLine("A- Alugar filme");
			Console.WriteLine("D- Devolver filme");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.Clear();
			return opcaoUsuario;
		}
    }
}
