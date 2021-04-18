using System;

namespace Mymusic
{
    class Program
    {
        static MusicasRepositorio repositorio = new MusicasRepositorio();
        static void Main(string[] args)
        {
            string opcaoDoUsuario = ObterOpcaoDoUsuario();

            while(opcaoDoUsuario.ToUpper() != "E")
            {
                switch(opcaoDoUsuario)
                {
                    case "1":
                        ListarMusicas();
                    break;
                    case "2":
                        InserirMusica();
                    break;
                    case "3":
                        AtualizarMusica();
                    break;
                    case "4":
                        ExcluirMusica();
                    break;
                    case "5":
                        VisualizarMusica();
                    break;
                    case "C":
                        Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoDoUsuario = ObterOpcaoDoUsuario();
            }
            Console.WriteLine("Obrigado(a) por utilizar nossos serviços!!!");
            Console.ReadLine();
        }
            //Listar músicas
        private static void ListarMusicas()
        {
            Console.WriteLine("Listar músicas");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma música encontrada.");
                return;
            }

            foreach(var musica in lista)
            {
                var excluido = musica.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", musica.retornaId(), musica.retornaTitulo(), (excluido ? "Sim" : ""));
            }
        }
            //Inserir músicas
        private static void InserirMusica()
        {
            Console.WriteLine("Inserir nova música");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da música: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do artista: ");
            string entradaArtista = Console.ReadLine();

            Console.Write("Digite o nome do album: ");
            string entradaAlbum = Console.ReadLine();

            Musicas novaMusica = new Musicas(id: repositorio.ProximoId(),
                                             genero: (Genero)entradaGenero, 
                                             titulo: entradaTitulo,
                                             artista: entradaArtista,
                                             album: entradaAlbum);
            
            repositorio.Insere(novaMusica);
        }
            //Atualizar músicas
        private static void AtualizarMusica()
        {
            Console.WriteLine("Digite o Id da música: ");
            int indiceMusica = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da música: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do artista: ");
            string entradaArtista = Console.ReadLine();

            Console.Write("Digite o nome do album: ");
            string entradaAlbum = Console.ReadLine();

            Musicas atualizarMusica = new Musicas(id: indiceMusica,
                                                  genero: (Genero)entradaGenero,
                                                  titulo: entradaTitulo,
                                                  artista: entradaArtista,
                                                  album: entradaAlbum);
            repositorio.Atualiza(indiceMusica, atualizarMusica);
        }
        
            // Excluir música
        private static void ExcluirMusica()
        {
            Console.WriteLine("Digite o id da música: ");
            int indiceMusica = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceMusica);
        }

            // Visualizar música
        private static void VisualizarMusica()
        {
            Console.WriteLine("Digite o id da música: ");
            int indiceMusica = int.Parse(Console.ReadLine());

            var musica = repositorio.RetornaPorId(indiceMusica);

            Console.WriteLine(musica);
        }

        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("My Music a seu dispor!!");
            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada:");

            Console.WriteLine("1 - Listar músicas");
            Console.WriteLine("2 - Inserir música");
            Console.WriteLine("3 - Atualizar música");
            Console.WriteLine("4 - Excluir música");
            Console.WriteLine("5 - Visualizar música");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("E - Sair");
            Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;
        }
    }
}