using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICourseService
    {
        Task<SuccessResponse<IEnumerable<CourseDto>>> GetCoursesAsync();
        Task<SuccessResponse<CourseDto>> CreateCoursesAsync(CreateCourseDto course);
    }
}
