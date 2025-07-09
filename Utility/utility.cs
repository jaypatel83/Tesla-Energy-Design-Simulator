using System.Text.Json;
namespace EnergyDesignSimulator.Utility
{
    public static class JsonValidator
    {
        public static bool IsValidJson(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return false;
            }

            try
            {
                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    // If parsing succeeds, the JSON is valid
                    return true;
                }
            }
            catch (JsonException)
            {
                // If parsing fails, the JSON is invalid
                return false;
            }
        }
    }
}