using System;
using DIO.CrudSeries.Classes;
using DIO.CrudSeries.Enumerable;

namespace DIO.CrudSeries
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string option = getOption();

            while (option.ToUpper() != "X")
            {


                switch (option.ToUpper())
                {
                    case "1":
                        listSeries();
                        break;
                    case "2":
                        createSerie();
                        break;
                    case "3":
                        updateSerie();
                        break;
                    case "4":
                        removeSerie();
                        break;
                    case "5":
                        viewSerie();
                        break;
                    case "X":
                    case "x":
                        break;
                    default:
                        Console.WriteLine("Erro - Digite uma opção válida");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadLine();

                option = getOption();
            }
        }

        public static string getOption()
        {
            Console.Clear();
            Console.WriteLine("-------------------- Séries --------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Digite uma opção: ");
            return Console.ReadLine();
        }

        public static void header(string desc)
        {
            Console.Clear();
            Console.WriteLine($"-------------------- {desc} --------------------");
            Console.WriteLine();
        }

        public static void listSeries()
        {
            header("Lista de séries");
            var series = repository.ListSeries();
            if(series.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in series)
            {
                Console.WriteLine($"#ID {serie.getId()} - {serie.getTitle()}");
                Console.WriteLine($"------------------------------------------------");
            }
        }
        public static string input(string desc)
        {
            string line = "";
            while (true)
            {
                Console.Write($"{desc}: ");
                line = Console.ReadLine();

                if (line.Length > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"O campo obrigatório");
                }
            }
            return line;
        }

        public static int inputNumber(string desc)
        {
            while (true)
            {
                Console.Write($"{desc}: ");
                if(int.TryParse(Console.ReadLine(), out int num)){
                    return num;
                }else{
                    Console.WriteLine("Campo deve ser um número inteiro");
                }
            }
        }

        public static void createSerie()
        {
            header("Inserir série");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            var genre = inputNumber("Gênero");
            var title = input("Titulo");
            var description = input("Descrição");
            var year = inputNumber("Ano");

            var serie = new Series(id: repository.NextId(), title, description, year, (Genre)genre);

            repository.Create(serie);
            Console.WriteLine("Série inserida com sucesso");
        }

        public static Series GetSeriesById()
        {
            var id = inputNumber("Id da série");
            var serie = repository.GetById(id);
            if(serie == null)
            {
                Console.WriteLine("Série não encontrada");
                return null;
            }
            return serie;
        }

        public static void removeSerie()
        {
            header("Excluir Série");
            
            var serie = GetSeriesById();

            if(serie == null)
            {
                return;
            }
            repository.Remove(serie.getId());
            Console.WriteLine("Série excluida com sucesso");
        }

        public static void updateSerie()
        {
            header("Atualizar Série");
            
            var serie = GetSeriesById();

            if(serie == null)
            {
                return;
            }

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            var genre = inputNumber("Gênero");
            var title = input("Titulo");
            var description = input("Descrição");
            var year = inputNumber("Ano");

            var serieUpdated = new Series(id: serie.getId(), title, description, year, (Genre)genre);

            repository.Update(serie.getId(), serieUpdated);
            Console.WriteLine("Série atualizada com sucesso");
        }

        public static void viewSerie()
        {
            header("Visualizar Série");
            
            var serie = GetSeriesById();

            if(serie == null)
            {
                return;
            }
            Console.WriteLine(serie.ToString());
        }
    }
}
