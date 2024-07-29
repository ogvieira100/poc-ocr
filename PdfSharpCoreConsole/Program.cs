
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.Content.Objects;
using PdfSharpCore.Pdf.Content;
using System.Text;

namespace Ola
{
    class TestClass
    {

        static string ExtractText(PdfPage page)
        {
            var content = ContentReader.ReadContent(page);
            return ExtractTextFromContent(content);
        }

        static string ExtractTextFromContent(CObject content)
        {
            var text = string.Empty;
            if (content is COperator op && op.OpCode.Name == OpCodeName.Tj.ToString())
            {
                foreach (var operand in op.Operands)
                {
                    if (operand is CString cString)
                    {
                        text += cString.Value;
                    }
                }
            }
            else if (content is CSequence sequence)
            {
                foreach (var element in sequence)
                {
                    text += ExtractTextFromContent(element);
                }
            }
            return text;
        }
        static async Task Main(string[] args)
        {

            string pdfPath = "D:\\Projetos\\poc-ocr\\Sln\\atestados\\download2.pdf";

            try
            {
                PdfDocument document = PdfReader.Open(pdfPath, PdfDocumentOpenMode.ReadOnly);
                StringBuilder txtTotal = new StringBuilder();   
                for (int pageIndex = 0; pageIndex < document.PageCount; pageIndex++)
                {
                    PdfPage page = document.Pages[pageIndex];
                    string text = ExtractText(page);
                   
                    Console.WriteLine($"Texto da página {pageIndex + 1}:");
                    Console.WriteLine(text);
                    txtTotal.Append(text + Environment.NewLine);
                }

                var tot =  txtTotal.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

        }
    }
}