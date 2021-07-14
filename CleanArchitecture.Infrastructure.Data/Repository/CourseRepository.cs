using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDBContext _ctx;
        public CourseRepository(UniversityDBContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<Course> CourseExistAsync(int id)
        {
            var course = await _ctx.Courses.FindAsync(id);

            if (course == null) return null;

            return course;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            await _ctx.Courses.AddAsync(course);
            await _ctx.SaveChangesAsync();

            return course;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _ctx.Courses.ToListAsync();
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            await _ctx.SaveChangesAsync();

            return course;
        }
    }
}
