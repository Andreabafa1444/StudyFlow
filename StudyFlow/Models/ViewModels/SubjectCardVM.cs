namespace StudyFlow.Models.ViewModels
{
    public class SubjectCardVM
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }

        public int EvaluationsCount { get; set; }
        public double Average { get; set; }
    }
}
