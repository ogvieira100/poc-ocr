using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace Ola
{
    class TestClass
    {
        static async Task Main(string[] args)
        {

            string pdfPath = "D:\\Projetos\\poc-ocr\\Sln\\atestados\\download.pdf";

            try
            {
                using (PdfDocument document = PdfDocument.Open(pdfPath))
                {
                    foreach (Page page in document.GetPages())
                    {
                        string text = page.Text;
                        Console.WriteLine($"Texto da página {page.Number}:");
                        Console.WriteLine(text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

        }
    }
}