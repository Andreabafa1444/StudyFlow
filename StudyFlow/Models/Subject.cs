using System;
using System.Collections.Generic;

namespace StudyFlow.Models
{
    public class Subject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public int Credits { get; set; }

        public SubjectStatus Status { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}
