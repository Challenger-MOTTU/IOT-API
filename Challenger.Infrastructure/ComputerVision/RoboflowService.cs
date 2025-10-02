using System.Net.Http.Headers;

namespace Challenger.Infrastructure.ComputerVision
{
    public class RoboflowService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "D7bUzySnqrUBN07jWBX1";
        private const string ModelEndpoint = "https://detect.roboflow.com/challengeproject-zc1sb/1";

        public RoboflowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Envia uma imagem para o Roboflow e retorna as detecções.
        /// </summary>
        public async Task<string> AnalyzeImageAsync(Stream imageStream)
        {
            using var content = new MultipartFormDataContent();
            var imageContent = new StreamContent(imageStream);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            content.Add(imageContent, "file", "image.jpg");

            var response = await _httpClient.PostAsync($"{ModelEndpoint}?api_key={ApiKey}", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Erro ao chamar Roboflow: {response.StatusCode} - {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}