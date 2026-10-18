
using src;
using System.Collections.Generic;

public class CourseStore
{
    private readonly List<Course> _courses = new List<Course>();

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

    public List<Course> GetAll()
    {
        return new List<Course>(_courses);
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
