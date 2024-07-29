
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Text;

namespace Ola
{
    class TestClass
    {
        static async Task Main(string[] args)
        {
            string pdfPath = "D:\\Projetos\\poc-ocr\\Sln\\atestados\\download2.pdf";

            try
            {
                StringBuilder txtTotal = new StringBuilder();
                using (PdfReader pdfReader = new PdfReader(pdfPath))
                using (PdfDocument pdfDoc = new PdfDocument(pdfReader))
                {
                    for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                    {
                        string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page));
                        Console.WriteLine($"Texto da página {page}:");
                        Console.WriteLine(text);
                        txtTotal.Append(text);
                    }
                }
                var tot = txtTotal.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}