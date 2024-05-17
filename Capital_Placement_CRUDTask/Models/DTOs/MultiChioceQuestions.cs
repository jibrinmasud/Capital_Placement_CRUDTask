namespace Capital_Placement_CRUDTask.Models.DTOs
{
    public class MultiChioceQuestions
    {
        public string? Type { get; set; }
        public string? Question { get; set; }
        public string? Choice { get; set; }
        public bool EnableMore { get; set; }
        public string? MaxNumber { get; set; }
    }
}