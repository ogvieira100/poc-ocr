using System;
using Tesseract;

class Program
{
    static void Main(string[] args)
    {
        string imagePath = "C:\\Users\\ogvieira\\Downloads\\ocrevus 1.jpg";
        string datapath = @"D:\tessdata";  // Caminho para o diretório tessdata
        string language = "por";          // Código do idioma para português do Brasil
        EngineMode engineMode = EngineMode.Default;

        try
        {
            using (var engine = new TesseractEngine(datapath, language, engineMode))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        Console.WriteLine("Texto extraído da imagem:");
                        Console.WriteLine(text);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro: " + e.Message);
        }
    }
}
