using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ola
{
    class TestClass
    {
        static async Task Main(string[] args)
        {

            /*
             in postman switch to raw data (currently you are in form-data).
then insert your desired payload:

{
      "username":"admin",
      "id":"2d06aa3b-c25a-4499-948a-86341ac4adc5",
      "email":null,
      "firstName":"admin",
      "lastName":"admin",
      "createdTimestamp":1638268009973
}
and fire the request.

BTW, when you say

The endpoint except a dict like this:

user_data = {  
      "username":"admin",  
      "id":"2d06aa3b-c25a-4499-948a-86341ac4adc5",  
      "email":null,  
      "firstName":"admin",  
      "lastName":"admin",  
      "createdTimestamp":1638268009973
},
you actually mean the endpoint expect only the dictionary part, because user_data is simply a variable name in your python code, completely unrelated to any request configuration.
the reason i specify it is because you wrote it as a key you the postman's request form-data (the picture you uploaded)
             
             */

            var http = new HttpClient();
            var keyApi = Environment.GetEnvironmentVariable("LlamaApiKey");

            //https://api.cloud.llamaindex.ai/api/parsing/upload
            //http.BaseAddress = new Uri("https://api.cloud.llamaindex.ai");

            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", keyApi);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formData = new MultipartFormDataContent();

            using (var form = new MultipartFormDataContent())
            {
                using (var fileStream = new FileStream("C:\\Users\\ogvieira\\Downloads\\rgnovo.pdf", FileMode.Open, FileAccess.Read))
                {
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    form.Add(fileContent, "file", Path.GetFileName("C:\\Users\\ogvieira\\Downloads\\rgnovo.pdf"));

                    var user_data = new {
                      username = "admin",  
                      id = "2d06aa3b-c25a-4499-948a-86341ac4adc5",  
                      email = "",  
                      firstName = "admin",  
                      lastName = "admin",  
                      createdTimestamp = 1638268009973
                    };

                // Adicionando dados do usuário
                form.Add(new StringContent(JsonConvert.SerializeObject(user_data)), "user_data");

                    var response = await http.PostAsync("https://api.cloud.llamaindex.ai/api/parsing/upload", form);
                    var responseContent = await response.Content.ReadAsStringAsync();



                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("File uploaded successfully.");
                        Console.WriteLine("Response: " + responseContent);
                    }
                    else
                    {
                        Console.WriteLine("Failed to upload file.");
                        Console.WriteLine("Response: " + responseContent);
                    }
                }
            }

            /**/

            // Adicione o arquivo
            //using (var fileStream = File.OpenRead("C:\\Users\\ogvieira\\Downloads\\contagas_2027.jpg"))
            //using (var streamContent = new StreamContent(fileStream))
            //{
           // var fileStream = File.OpenRead("C:\\Users\\ogvieira\\Downloads\\contagas_2028.jpg");
           // var fileContent = new StreamContent(fileStream);
           // byte[] byteArray = new byte[fileStream.Length];
           // fileStream.Read(byteArray, 0, byteArray.Length);
          //  using var content = new ByteArrayContent(byteArray);
           // fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
           // formData.Add(fileContent, "file", "contagas_2028.jpg");
            //  content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

          
            /*
                streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                
                */
            // Crie a mensagem de requisição HTTP
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.cloud.llamaindex.ai/api/parsing/upload")
            //    {
            //        Content = formData,

            //    };
            //request.Headers.Add("username", "admin");
            //request.Headers.Add("id", "2d06aa3b-c25a-4499-948a-86341ac4adc5");
            //request.Headers.Add("firstName", "admin");
            //request.Headers.Add("lastName", "admin");
            //request.Headers.Add("createdTimestamp", "1638268009973");
            //request.Headers.Add("createdTimestamp", "1638268009973");
            //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", keyApi);
            // request.Headers.Add("Content-Type", "multipart/form-data; boundary=--------------------------021201266231478067017183");
            // Exiba os detalhes da mensagem HTTP para depuração
            // Console.WriteLine(request);
            // Console.WriteLine(await formData.ReadAsStringAsync());

           // HttpResponseMessage response = await http.SendAsync(request);   
           // HttpResponseMessage response = await http.PostAsync("https://api.cloud.llamaindex.ai/api/parsing/upload", formData);

            // Verifique a resposta
            //if (response.IsSuccessStatusCode)
            //    {
            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        Console.WriteLine(responseBody);
            //    }
            //    else
            //    {
            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        Console.WriteLine($"Erro na requisição: {response.StatusCode}");
            //    }
          //  }

        }
    }
}