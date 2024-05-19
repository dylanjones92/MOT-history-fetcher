using System.Globalization;
using System.Text.Json.Serialization;

namespace MotHistoryFetcher
{
    public class MotTest
    {
        [JsonPropertyName("completedDate")]
        public string CompletedDateString { get; set; }
        [JsonIgnore]
        public DateTime CompletedDate
        {
            get
            {
                DateTime date;
                DateTime.TryParseExact(CompletedDateString, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                return date;
            }
        }
        public string TestResult { get; set; }
        [JsonPropertyName("expiryDate")]
        public string ExpiryDateString { get; set; }
        [JsonIgnore]
        public DateTime? ExpiryDate
        {
            get
            {
                DateTime date;
                DateTime.TryParseExact(ExpiryDateString, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                return date;
            }
        }
        public int OdometerValue { get; set; }
        public string OdometerUnit { get; set; }
        public string MotTestNumber { get; set; }
    }
}
