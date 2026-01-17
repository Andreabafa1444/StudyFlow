using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyFlow.Models
{
    public class Evaluation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public int Percentage { get; set; }

        public double Grade { get; set; }

        public string SubjectId { get; set; } = string.Empty;

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } = null!;
    }
}
