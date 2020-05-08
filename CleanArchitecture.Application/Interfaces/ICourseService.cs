using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    interface ICourseService
    {
        IEnumerable<CourseVeiwModel> GetCourses();
    }
}
