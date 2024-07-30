using IronOcr;

public class Program
{
    public static async Task Main(string[] args)
    {
        string imagePath = "C:\\Users\\ogvieira\\Downloads\\ocrevus 1.jpg";

        try
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput(imagePath))
            {
                var Result = Ocr.Read(Input);
                string text = Result.Text;
                Console.WriteLine("Texto extraído da imagem:");
                Console.WriteLine(text);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro: " + e.Message);
        }
    }
}