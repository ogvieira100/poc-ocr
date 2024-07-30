using Xceed.Words.NET;

namespace Ola
{
    class TestClass
    {
        static async Task Main(string[] args)
        {

            string docxPath = "path/to/your/document.docx";

            try
            {
                using (DocX document = DocX.Load(docxPath))
                {
                    string text = document.Text;
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
}