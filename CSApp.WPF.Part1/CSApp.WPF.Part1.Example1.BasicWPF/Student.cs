using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApp.WPF.Part1.Example1.BasicWPF
{
    public class Student
    {
        public string StudentName { get; set; }
        public bool IsEnrolled { get; set; }

        public Student(string name, bool ch)
        {
            StudentName = name;
            IsEnrolled = ch;
        }
        public string FullStudentData
        {
            get { return StudentName + "\t" + IsEnrolled; }
        }
    }

    public class StudentList : ObservableCollection<Student>
    {
        public StudentList()
        {
            Add(new Student("Jack Brown", true));
            Add(new Student("John Smith", true));
            Add(new Student("Alice White", false));
        }
    }
}
