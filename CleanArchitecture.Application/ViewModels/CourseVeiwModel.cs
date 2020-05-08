using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class CourseVeiwModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
