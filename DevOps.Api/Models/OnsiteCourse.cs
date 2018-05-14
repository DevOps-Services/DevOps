﻿using System;
using System.Collections.Generic;

namespace DevOps.Api.Models
{
    public partial class OnsiteCourse
    {
        public int CourseId { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }

        public Course Course { get; set; }
    }
}
