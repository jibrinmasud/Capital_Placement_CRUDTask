using Capital_Placement_CRUDTask.Models.DTOs;

namespace Capital_Placement_CRUDTask.Models
{
    public class Questions
    {
        public string? id { get; set; }
        public string? questionstype { get; set; }

        public ParagrapQuestion? ParagrapQuestion { get; set; }
        public YesNoQuestion? YesNoQuestion { get; set; }
        public DropDown? DropDown { get; set; }
        public DateQuestion? DateQuestion { get; set; }
        public NumberQuestion? NumberQuestion { get; set; }
    }
}