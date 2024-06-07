using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PractiseC_
{
    internal class Group
    {
        private static int id = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; private set; }
        public Group(string name,int limit)
        {
            Id=id++;
            Name=name;
            Students = new List<Student>();
            Limit = limit;
        }
        public void AddStudentToGroup(Student student)
        {
            Students.Add(student);
        }
        public void GetDetails()
        {
            Console.WriteLine($"Id : {Id} Group's Name : {Name} Limit : {Limit}");
        }
    }
}
