using System;
using System.Text.Json.Serialization;

namespace MotHistoryFetcher
{
    public class MotHistory
    {
        [JsonPropertyName("registration")]
        public required string Registration { get; set; }
        [JsonPropertyName("make")]
        public string? Make { get; set; }
        [JsonPropertyName("model")]
        public string? Model { get; set; }
        [JsonPropertyName("manufactureYear")]
        public int ManufactureYear { get; set; }
        [JsonPropertyName("fuelType")]
        public string? FuelType { get; set; }
        [JsonPropertyName("primaryColour")]
        public string? PrimaryColour { get; set; }
        [JsonPropertyName("dvlaId")]
        public string? DvlaId { get; set; }
        [JsonPropertyName("motTestExpiryDate")]
        public DateTime? MotTestExpiryDate { get; set; }
        [JsonPropertyName("motTests")]
        public List<MotTest> MotTests { get; set; } = new List<MotTest>();
        public string MotExpiryDateString
        {
            get
            {
                if (MotTestExpiryDate == null) return "N/A";
                return MotTestExpiryDate.ToString();
            }
        }

    }
}
