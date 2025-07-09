namespace EnergyDesignSimulator.Models
{
    public class Design
    {
        public int Id { get; set; }
        public string LayoutName { get; set; }
        public int PanelCount { get; set; }
        public string Coordinates { get; set; } // JSON string
        public DateTime CreatedAt { get; set; }
    }
}