using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics;

public class CourseStore
{
    private readonly List<Course> _courses = new();

    public void Add(Course course)
    {
        _courses.Add(course);
    }

    public Course? GetById(int id)
    {
        foreach (Course course in _courses)
        {
            if (course.Id == id)
            {
                return course;
            }
        }

        return null;
    }

    public IReadOnlyList<Course> GetAll()
    {
        return _courses.AsReadOnly();
    }

    public bool Remove(int id)
    {
        for (int i = 0; i < _courses.Count; i++)
        {
            if (_courses[i].Id == id)
            {
                _courses.RemoveAt(i);
                return true;
            }
        }

        return false;
    }
}
