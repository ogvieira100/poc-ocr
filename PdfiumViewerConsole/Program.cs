
using PdfiumViewer;
using System.Text;

namespace Ola
{
    class TestClass
    {
        static async Task Main(string[] args)
        {
            string pdfPath = "D:\\Projetos\\poc-ocr\\Sln\\atestados\\download.pdf";

            try
            {
                using (var document = PdfDocument.Load(pdfPath))
                {
                    var text = new StringBuilder();

                    for (int page = 0; page < document.PageCount; page++)
                    {
                        text.Append(document.GetPdfText(page));
                    }

                    Console.WriteLine("Texto do PDF:");
                    Console.WriteLine(text.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

        }
    }
}