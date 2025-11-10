using System.Net.Http.Headers;

namespace Challenger.Infrastructure.ComputerVision
{
    public class RoboflowService
    {
        private readonly HttpClient _http;

        private const string ApiKey = "D7bUzySnqrUBN07jWBX1";
        private const string ModelEndpoint = "https://detect.roboflow.com/challengeproject-zc1sb/1";

        public RoboflowService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> AnalyzeAsync(byte[] imageBytes)
        {
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(imageBytes)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("image/jpeg") }
            }, "file", "image.jpg");

            var url = $"{ModelEndpoint}?api_key={ApiKey}";

            var response = await _http.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}