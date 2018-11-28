using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("[ 1 ] Extrair arquivo");
                Console.WriteLine("[ 0 ] Sair do Software");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        ExtrairArquivo();
                        break;
                    case 0:
                        saiPrograma();
                        break;
                    default:
                        Console.Write("Opção inválida!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
        }

        private static void ExtrairArquivo()
        {
            string folderPathDownload = @"D:\Arquivos\";
            string filePath = folderPathDownload;

            Console.WriteLine("Digite o nome do arquivo .zip");
            string filename = Console.ReadLine();
            filePath += filename;
            try
            {
                if (File.Exists(filePath) && filePath.EndsWith(".zip"))
                {
                    string fileImg = filePath.Substring(0, filePath.Length - 4) + ".img";
                    if (!File.Exists(fileImg))
                    {
                        ZipArchive archive = ZipFile.OpenRead(filePath);
                        ZipArchiveEntry entry = archive.Entries[0];
                        if (entry.FullName.EndsWith(".img", StringComparison.OrdinalIgnoreCase))
                        {
                            entry.ExtractToFile(Path.Combine(folderPathDownload, fileImg), true);
                        }
                        Console.WriteLine("Sucesso");

                    }
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado ou em formato incorreto!!!!");
                }
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("Erro " + e);
            }
        }

        private static void saiPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
        }
    }
}
