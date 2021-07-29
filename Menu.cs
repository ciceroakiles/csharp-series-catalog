using System;

namespace series_catalog
{
    class Menu
    {
        private static SerieRepository serieRep = new SerieRepository();
        public static void Start()
        {
            string op;
            do {
                op = selecionarOpcao();
                switch (op) {
                    case "1": {
                        adicionarSerie();
                    } break;
                    case "2": {
                        verSerie();
                    } break;
                    case "3": {
                        atualizarSerie();
                    } break;
                    case "4": {
                        deletarSerie();
                    } break;
                    case "5": {
                        listarSeries();
                    } break;
                    default: break;
                }
                pausa();
            } while (op != "x");
        }

        private static void pausa() {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static string selecionarOpcao() {
            string str;
            Console.WriteLine("Opções:");
            Console.WriteLine("1 - Nova série");
            Console.WriteLine("2 - Ver série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Deletar série");
            Console.WriteLine("5 - Listar séries");
            Console.WriteLine("X - Sair");
            str = Console.ReadLine().ToLower();
            Console.WriteLine();
            return str;
        }

        private static void adicionarSerie() {
            Console.WriteLine("Incluir nova série");
            // Inserção
            serieRep.insert(dados(-1));
            Console.WriteLine();
            Console.WriteLine("Série adicionada com sucesso.");
        }

        private static void atualizarSerie() {
            Console.WriteLine("Atualizar série");
            int id = validaId();
            Serie s = retornaSerie(id);
            if (s == null || !s.exists() || id == -1) {
                Console.WriteLine("Série não encontrada.");
                return;
            }
            // Atualização
            serieRep.update(id, dados(id));
            Console.WriteLine("Série atualizada com sucesso.");
        }

        private static void verSerie() {
            Console.WriteLine("Ver série");
            int id = validaId();
            Serie s = retornaSerie(id);
            if (s == null || id == -1) {
                Console.WriteLine("Série não encontrada.");
                return;
            }
            // Leitura
            Console.WriteLine();
            Console.WriteLine(s);
        }

        private static void deletarSerie() {
            Console.WriteLine("Deletar série");
            int id = validaId();
            Serie s = retornaSerie(id);
            if (s == null || !s.exists() || id == -1) {
                Console.WriteLine("Série não encontrada.");
                return;
            }
            // Mensagem de confirmação
            Console.Write("Deseja realmente excluir a série? (s: sim) ");
            string op = Console.ReadLine().ToLower();
            if (op == "s") {
                // Exclusão
                serieRep.deleteById(id);
                Console.WriteLine("Série deletada da lista.");
            }
        }

        private static void listarSeries() {
            var lista = serieRep.listAll();
            int n = 0;
            Console.WriteLine("Lista de séries:");
            foreach (var s in lista) {
                if (s.exists()) {
                    Console.WriteLine("ID: " + s.getId() + " - Título: " + s.getTitulo());
                    n++;
                }
            }
            if (lista.Count == 0 || n == 0) {
                Console.WriteLine("Nenhuma série encontrada.");
            }
        }

        /*
         * Métodos auxiliares
         */

        // Reaproveitamento de código: criar ou atualizar
        private static Serie dados(int atual) {
            foreach (int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine(i + " - " + Enum.GetName(typeof(Genero), i));
            }
            // Dados
            Console.Write("Selecione um gênero: ");
            int gen = int.Parse(Console.ReadLine());
            Console.Write("Título da série: ");
            string title = Console.ReadLine();
            Console.Write("Descrição: ");
            string desc = Console.ReadLine();
            Console.Write("Ano de início: ");
            int ano = int.Parse(Console.ReadLine());
            // Ajuste no id
            int id = ((atual == -1) ? serieRep.lastId() : atual);
            // Criação do objeto
            Serie novaSerie = new Serie(
                id, ano, title, desc, (Genero)gen
            );
            return novaSerie;
        }

        //  Busca e validação
        private static Serie retornaSerie(int id) {
            Serie test;
            try {
                test = serieRep.getById(id);
            } catch (Exception ex) {
                test = null;
            }
            return test;
        }

        private static int validaId() {
            Console.Write("Digite o ID da série: ");
            int id;
            try {
                id = int.Parse(Console.ReadLine());
            } catch (Exception ex) {
                // Código de erro
                id = -1;
            }
            return id;
        }
    }
}
