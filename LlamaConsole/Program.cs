using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        // URL do endpoint
        string url = "https://api.cloud.llamaindex.ai/api/parsing/upload";

        // Token de autorização
        string token = Environment.GetEnvironmentVariable("LlhamaParsVar");

        // Caminho do arquivo a ser enviado
        string filePath = "C:\\Users\\ogvieira\\Downloads\\rgcostas2026.jpg";

        // Nome do campo do formulário que contém o arquivo
        string fileFieldName = "file";

        using (var client = new HttpClient())
        using (var content = new MultipartFormDataContent())
        {
            // Configurar o cabeçalho de autorização
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Adicionar o arquivo ao conteúdo multipart/form-data
            byte[] fileBytes = File.ReadAllBytes(filePath);
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = fileFieldName,
                FileName = Path.GetFileName(filePath)
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            content.Add(fileContent);

            // Enviar a requisição POST
            var response = await client.PostAsync(url, content);

            // Processar a resposta
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resposta: {responseContent}");
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
            }
        }
    }
}
