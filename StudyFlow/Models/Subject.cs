using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudyFlow.Models
{
    public class Subject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }

        public int UserId { get; set; }

        [ValidateNever]
        public User User { get; set; } = null!;

        public SubjectStatus Status { get; set; }

        [ValidateNever]
        public List<Evaluation> Evaluations { get; set; } = new();
    }
}
