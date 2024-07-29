using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

class Program
{
    static void Main(string[] args)
    {
        string docxPath = "path/to/your/document.docx";

        try
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(docxPath, false))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;
                string text = body.InnerText;
                Console.WriteLine("Texto do documento Word:");
                Console.WriteLine(text);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro: " + e.Message);
        }
    }
}
