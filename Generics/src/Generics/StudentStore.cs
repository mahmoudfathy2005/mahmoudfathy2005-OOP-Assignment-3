using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class StudentStore
    {
        private readonly List<Student> _students = new();

        public void Add(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student Dont Allow Null");
            _students.Add(student);
        }

        public Student? GetById(int id)
        {
            foreach (Student student in _students)
            {
                if (student.Id == id) return student;

            }
            return null;
        }

        public IReadOnlyList<Student> GetAll()
        {
            return _students;
        }

        public bool Remove(int id)
        {
            foreach (Student student in _students)
            {
                if (student.Id == id)
                    _students.Remove(student);
                return true;
            }
            return false;
        }
    }
}
