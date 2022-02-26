using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;

namespace BusinessLogic
{
    public class Student
    {
        private readonly LibraryContext _context;

        public Student(LibraryContext context)
        {
            _context = context;
        }
        public List<Entity.Student> GetStudents()
        {
            return _context.Student.ToList(); 
        }
    }
}
