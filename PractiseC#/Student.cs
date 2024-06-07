using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseC_
{
    internal class Student
    {
        private static int id=1;
        public int Id { get;private set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Dictionary<string,List<double>> Grades { get; set; }
        public DateTime BirthDay { get; set; }
        public Student(string name,string surname, DateTime birthDay)
        {
            Id = id++;
            Name = name;
            SurName = surname;
            BirthDay = birthDay;
            Grades=new Dictionary<string, List<double>>();
        }
        public string GetDetails()
        {
            return$" Id : {Id} Name : {Name}  Surname : {SurName}  Birthday : {BirthDay.ToString("dd.MM.yyyy")} ";
        }
    }
}
