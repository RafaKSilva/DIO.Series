using System;
using System.Linq;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        Console.WriteLine();
                        PressioneParaContinuar();
                        break;
                        

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("-Visualizar Série-");
            if (ObterListaDeSeries())
            {
                PressioneParaContinuar();
                return;
            }
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine();
            Console.WriteLine(serie);
            PressioneParaContinuar();
        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine("-Excluir Série-");
            if (ObterListaDeSeries())
            {
                PressioneParaContinuar();
                return;
            }
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("-Atualizar Série-");
            if (ObterListaDeSeries())
            {
                PressioneParaContinuar();
                return;
            }
            Console.Write("Digite o id da série: ");
            int indiceId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.Write("Digite o Genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceId,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Atualiza(indiceId, novaSerie);
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("-Inserir Nova Série-");
            Console.WriteLine();
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Digite o Genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("-Listar Séries-");
            ObterListaDeSeries();
            PressioneParaContinuar();
        }

        private static bool ObterListaDeSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.WriteLine();
                return true;
            }

            Console.WriteLine();
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- *Excluído*" : ""));
            }
            Console.WriteLine();
            return false;
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("-Lista de Opções-");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir séries");
            Console.WriteLine("5 - Visualizar séries");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void PressioneParaContinuar()
        {
            Console.Write("<pressione para qualque tecla para continuar>");
            Console.ReadKey(false);
        }

    }
}
