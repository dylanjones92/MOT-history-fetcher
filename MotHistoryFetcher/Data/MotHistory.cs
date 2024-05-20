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
        public MotTest? LatestMot
        {
            get
            {
                return MotTests
                    .OrderByDescending(m => m.CompletedDate)
                    .FirstOrDefault();
            }
        }
        public string MotExpiryDateString
        {
            get
            {
                if (MotTestExpiryDate != null) return MotTestExpiryDate.Value.ToShortDateString();
                if (MotTests.Count == 0 || LatestMot?.ExpiryDate == null) return "N/A";
                return LatestMot.ExpiryDate.Value.ToShortDateString();
            }
        }
        public string MileageAtLastMot
        {
            get
            {
                if (LatestMot == null) return "N/A";

                return $"{LatestMot.OdometerValue} {LatestMot.OdometerUnit}";
            }
        }

    }
}
