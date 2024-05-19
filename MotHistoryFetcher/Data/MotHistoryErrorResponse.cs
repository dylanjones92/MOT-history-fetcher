using System.Text.Json.Serialization;

namespace MotHistoryFetcher
{
    internal class MotHistoryErrorResponse
    {
        [JsonPropertyName("httpStatus")]
        public string? HttpStatus { get; set; }
        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; set; }
        [JsonPropertyName("awsRequestId")]
        public string? AwsREquestId { get; set; }
    }
}