using System;

namespace AppDeCadastroDeAnimes
{
    class Program
    {
static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAnimes();
						break;
					case "2":
						InserirAnime();
						break;
					case "3":
						AtualizarAnime();
						break;
					case "4":
						ExcluirAnime();
						break;
					case "5":
						VisualizarAnime();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirAnime()
		{
			Console.Write("Digite o id da série: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAnime);
		}

        private static void VisualizarAnime()
		{
			Console.Write("Digite o id da série: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			var Anime = repositorio.RetornaPorId(indiceAnime);

			Console.WriteLine(Anime);
		}

        private static void AtualizarAnime()
		{
			Console.Write("Digite o id da série: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Anime atualizaAnime = new Anime(id: indiceAnime,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceAnime, atualizaAnime);
		}
        private static void ListarAnimes()
		{
			Console.WriteLine("Listar Animes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Anime cadastrado.");
				return;
			}

			foreach (var Anime in lista)
			{
                var excluido = Anime.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Anime.retornaId(), Anime.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirAnime()
		{
			Console.WriteLine("Inserir novo anime");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Anime novoAnime = new Anime(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoAnime);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo a Animex sua plataforma de animes online!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Animes");
			Console.WriteLine("2- Inserir novo Anime");
			Console.WriteLine("3- Atualizar Anime");
			Console.WriteLine("4- Excluir Anime");
			Console.WriteLine("5- Visualizar Anime");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
