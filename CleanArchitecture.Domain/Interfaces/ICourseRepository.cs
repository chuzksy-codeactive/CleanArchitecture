using CleanArchitecture.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> CourseExistAsync(int id);
        Task<Course> UpdateCourseAsync(Course course);
    }
}
