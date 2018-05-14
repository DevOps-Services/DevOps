using System;
using System.Collections.Generic;

namespace DevOps.Api.Models
{
    public partial class OnlineCourse
    {
        public int CourseId { get; set; }
        public string Url { get; set; }

        public Course Course { get; set; }
    }
}
